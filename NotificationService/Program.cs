using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GarageNotificationService.Data;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        // Configure database context
        services.AddDbContext<GarageDbContext>(options =>
            options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection"))); // Replace with your connection string

        // Add email service
        services.AddTransient<IEmailService, EmailService>();

        // Add notification service
        services.AddHostedService<ServiceExpirationReminderNotification>();
        services.AddHostedService<ServiceAppointmentReminderNotification>();

    })
    .Build();

await host.RunAsync();
