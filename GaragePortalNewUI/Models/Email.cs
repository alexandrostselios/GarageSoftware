namespace GaragePortalNewUI.Models
{
    public class Email
    {
        public long SenderID { get; set; }
        public long ReceiverID { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
