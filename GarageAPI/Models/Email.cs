using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models
{
    [NotMapped]
    public class Email
    {
        public long ReceiverID { get; set; }
        public string? Receiver { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}