using GarageAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System.Diagnostics;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class BrevoEmailController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public BrevoEmailController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("api/BrevoSendEmail")]
        public void SendEmail(string senderEmail, string senderName, string receiverEmail, string receiverName, string subject ,string message)
        {
            var apiInstance = new TransactionalEmailsApi();
            SendSmtpEmailSender sender = new SendSmtpEmailSender(senderName, senderEmail);

            SendSmtpEmailTo receiver1 = new SendSmtpEmailTo(receiverEmail, receiverName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(receiver1);

            string HtmlContent = null;
            string TextContent = message;

            try
            {
                var sendSmtpEmail = new SendSmtpEmail(sender, To, null, null, HtmlContent, TextContent, subject);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Issue: " + ex.Message);
            }
        }
    }
}