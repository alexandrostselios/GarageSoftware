using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models
{
    public class Email
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public long ReceiverID { get; set; }
        public string? Receiver { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime InsDate { get; set; }
    }
}