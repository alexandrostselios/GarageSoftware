using GarageNotificationService.Models.CarModels;

public interface IEmailService
{
    Task SendEmailAsync(string to, long recepientID, string subject, string body, string test);

    Task SendServiceAppointmentEmailAsync(string to, long recepientID, string subject, string body, string test);
}