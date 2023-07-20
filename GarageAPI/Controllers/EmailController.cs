using GarageAPI.Models;
using System.Net;
using System.Net.Mail;

namespace GarageAPI.Controllers
{
    public class EmailController : IEmailSender
    {
        public Task SendEmailAsync(Email email)
        {
            var emailProviderAccount = "alexandrostsel@hotmail.com";
            var emailProviderAccountPassword = "AlexTselios123456!@#$%^?";
            var emailSignature = "\n\nYours Sincerely\nAlexandros Tselios";

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(emailProviderAccount, emailProviderAccountPassword)
            };

            return client.SendMailAsync(new MailMessage(from: emailProviderAccount, to: email.Receiver, email.Subject, email.Message + emailSignature));
        }
    }
}