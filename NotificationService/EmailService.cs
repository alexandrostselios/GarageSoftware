using GarageNotificationService.Models.Email;
using NETCore.MailKit.Core;
using System.Net;
using System.Net.Http.Json;
using System.Net.Mail;

public class EmailService : IEmailService
{
    readonly Uri baseAddress = new Uri("https://localhost:7096/api");
    HttpClient client;

    public async Task SendEmailAsync(string recepient, long recepientID, string subject, string body, string? test)
    {
        var emailProviderAccount = "alexandrostselios@gmail.com";
        var emailProviderAccountPassword = "ofyfdvqfnvaetvnu";
        var emailSignature = "\n\nYours Sincerely\nAlexandros Tselios";

        client = new HttpClient();
        client.BaseAddress = baseAddress;

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(emailProviderAccount, emailProviderAccountPassword), // Use the generated app password here
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(emailProviderAccount, "Garage"),
            Subject = "Service Reminder",
            Body = body + test,
            IsBodyHtml = false
        };

        mailMessage.To.Add(recepient);

        await smtpClient.SendMailAsync(mailMessage);

        Email email = new Email { 
            GarageID = 1,
            Subject = mailMessage.Subject,
            Message = mailMessage.Body,
            InsDate = DateTime.Now,
            SenderID = 0,
            ReceiverID = recepientID
        };

        var response = await client.PostAsJsonAsync($"{client.BaseAddress}/AddNotificationEmail", email);
        client.Dispose();

    }

}
