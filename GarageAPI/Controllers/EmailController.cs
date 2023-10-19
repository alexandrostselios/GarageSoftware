using GarageAPI.Data;
using GarageAPI.Models;
using GarageAPI.Models.EngineerSpeciality;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace GarageAPI.Controllers
{
    public class EmailController : IEmailSender
    {
        private readonly GarageAPIDbContext dbContext;

        public EmailController(GarageAPIDbContext context)
        {
            dbContext = context;
        }

        public async Task SendEmailAsync(Email email)
        {
            var emailProviderAccount = "alexandrostsel@hotmail.com";
            var emailProviderAccountPassword = "AlexTselios123456!@#$%^?";
            var emailSignature = "\n\nYours Sincerely\nAlexandros Tselios";
            
            

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(emailProviderAccount, emailProviderAccountPassword)
            };

            await dbContext.Email.AddAsync(email);
            await dbContext.SaveChangesAsync();

            Task.Run(() => client.SendMailAsync(new MailMessage(from: emailProviderAccount, to: email.Receiver, email.Subject, email.Message + emailSignature)));
        }

        public async Task SendEmailToListAsync(List<Email> emails)
        {
            var emailProviderAccount = "alexandrostsel@hotmail.com";
            var emailProviderAccountPassword = "AlexTselios123456!@#$%^?";
            var emailSignature = "\n\nYours Sincerely\nAlexandros Tselios";

            for (int i = 0; i < emails.Count; i++)
            {
                using (var client = new SmtpClient("smtp-mail.outlook.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(emailProviderAccount, emailProviderAccountPassword)
                
                })
                Task.Run(() => client.SendMailAsync(new MailMessage(from: emailProviderAccount, to: emails[i].Receiver, emails[i].Subject, emails[i].Message + emailSignature)));
                await dbContext.Email.AddAsync(emails[i]);
                await dbContext.SaveChangesAsync();
            }   
        }
    }
}