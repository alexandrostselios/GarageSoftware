using GarageNotificationService.Data;
using GarageNotificationService.Models.CarModels;
using GarageNotificationService.Models.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Resources;
using System.Text.Json;

public class ServiceExpirationReminderNotification : BackgroundService
{
    private readonly ILogger<ServiceExpirationReminderNotification> _logger;
    private readonly IServiceProvider _serviceProvider;

    readonly Uri baseAddress = new Uri("https://localhost:7096/api");
    readonly HttpClient client;

    public ServiceExpirationReminderNotification(ILogger<ServiceExpirationReminderNotification> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;

        client = new HttpClient();
        client.BaseAddress = baseAddress;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Notification Service started.");

        // This will run until cancellation is requested
        while (!stoppingToken.IsCancellationRequested)
        {
            // Log the current time each time it checks
            _logger.LogInformation("Checking for notifications at: {time}", DateTime.Now);

            // Trigger the notifications
            await ServiceExpirationReminder(stoppingToken);

            // Wait for 2 minutes before checking again
            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
        }

        _logger.LogInformation("Notification Service stopped.");
    }

    private async Task ServiceExpirationReminder(CancellationToken stoppingToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<GarageDbContext>(); // Access your DbContext
            var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>(); // Access your email service

            var notificationDate = DateTime.Today.AddYears(-1).AddDays(0);


            string StoredProc = "exec GetCarServiceHistories @GarageID = 1, @NotificationDate = '" + notificationDate.ToString("yyyy-MM-dd") + "'";
            List<ServiceHistory> serviceHistory = await dbContext.ServiceHistory.FromSqlRaw(StoredProc).ToListAsync();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true // For readable JSON
            };

            foreach (var serviceItem in serviceHistory)
            {
                // Serialize the serviceItem into readable JSON
                string formattedJson = JsonSerializer.Serialize(serviceItem, options);

                // Clean up the JSON string by replacing escape sequences
                string cleanJson = formattedJson.Replace("\\r\\n", "\n").Replace("\\\"", "\"");

                // Output clean JSON to the log
                _logger.LogInformation(cleanJson);

                // For debugging, copy clean JSON
                //Console.WriteLine(cleanJson);

                // Send email notification
                var emailContent = ComposeServiceReminderEmail(serviceItem);
                await emailService.SendEmailAsync(serviceItem.CustomerEmail, serviceItem.CustomerID, "Car Management Notification", emailContent, null);

                // Mark notification as sent
                var notificationSent = await client.PutAsJsonAsync($"{client.BaseAddress}/UpdateServiceHistoryNotification/{serviceItem.ID}/false", serviceItem);

                if (!notificationSent.IsSuccessStatusCode)
                {
                    _logger.LogError($"Failed to update notification status for Service ID {serviceItem.ID}");
                }
            }

            // Save changes to the database
            await dbContext.SaveChangesAsync(stoppingToken);
        }
    }

    private static string ComposeServiceReminderEmail(ServiceHistory serviceHistory)
    {
        string formattedDate = serviceHistory.ServiceDate.HasValue
            ? serviceHistory.ServiceDate.Value.ToString("dd/MM/yyyy")
            : "unknown";

        return $"Hello,\n\n" +
               $"This is a reminder about the service of your car {serviceHistory.ManufacturerName} {serviceHistory.ModelName} with license plate {serviceHistory.LicencePlate}.\n\n" +
               $"Last service was performed on {formattedDate}.\n\n" +
               $"Last service was at {serviceHistory.ServiceKilometer} kilometers.\n\n" +
               $"Thanks,\nCar Management Team.";
    }
}