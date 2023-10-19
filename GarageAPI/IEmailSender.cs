using GarageAPI.Models;

namespace GarageAPI
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Email email);
        Task SendEmailToListAsync(List<Email> emails);
    }
}