using GarageNotificationService.Data;
using GarageNotificationService.Models.CarModels;
using GarageNotificationService.Models.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Resources;
using System.Text.Json;

public class ServiceAppointmentReminderNotification : BackgroundService
{
    private readonly ILogger<ServiceAppointmentReminderNotification> _logger;
    private readonly IServiceProvider _serviceProvider;

    readonly Uri baseAddress = new Uri("https://localhost:7096/api");
    readonly HttpClient client;

    public ServiceAppointmentReminderNotification(ILogger<ServiceAppointmentReminderNotification> logger, IServiceProvider serviceProvider)
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
            await ServiceAppointmentReminder(stoppingToken);

            // Wait for 2 minutes before checking again
            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
        }

        _logger.LogInformation("Notification Service stopped.");
    }

    private async Task ServiceAppointmentReminder(CancellationToken stoppingToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<GarageDbContext>(); // Access your DbContext
            var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>(); // Access your email service

            var notificationDate = DateTime.Today.AddDays(1);


            string StoredProc = "exec GetServiceAppointmentsToListLiteral @GarageID = 1";
            List<ServiceAppointment> serviceAppointments = await dbContext.ServiceAppointment.FromSqlRaw(StoredProc).ToListAsync();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true // For readable JSON
            };

            foreach (var serviceAppointment in serviceAppointments)
            {
                // Serialize the serviceItem into readable JSON
                string formattedJson = JsonSerializer.Serialize(serviceAppointment, options);

                // Clean up the JSON string by replacing escape sequences
                string cleanJson = formattedJson.Replace("\\r\\n", "\n").Replace("\\\"", "\"");

                // Output clean JSON to the log
                _logger.LogInformation(cleanJson);

                // For debugging, copy clean JSON
                //Console.WriteLine(cleanJson);

                // Send email notification
                var emailContent = ComposeServiceAppointmentEmail(serviceAppointment);
                await emailService.SendServiceAppointmentEmailAsync(serviceAppointment.CustomerEmail, serviceAppointment.CustomerID, "Car Management Notification", emailContent, null);

                // Mark notification as sent
                var notificationSent = await client.PutAsJsonAsync($"{client.BaseAddress}/UpdateServiceHistoryNotification/{serviceAppointment.ID}/false", serviceAppointment);

                if (!notificationSent.IsSuccessStatusCode)
                {
                    _logger.LogError($"Failed to update notification status for Service ID {serviceAppointment.ID}");
                }
            }

            // Save changes to the database
            await dbContext.SaveChangesAsync(stoppingToken);
        }
    }

    private static string ComposeServiceAppointmentEmail(ServiceAppointment serviceAppointment)
    {
        return $"Hello {serviceAppointment.Customer} ,\n\n" +
               $"This is a reminder about the Service appointment for {serviceAppointment.ManufacturerName} {serviceAppointment.ModelName} ({serviceAppointment.Kilometer} km) on {serviceAppointment.ServiceAppointmentDate} .\n\n" +
               $"Comments about this Service are: {serviceAppointment.ServiceAppointmentComments}.\n\n" +
               $"Thanks,\nCar Management Team.";
    }
}