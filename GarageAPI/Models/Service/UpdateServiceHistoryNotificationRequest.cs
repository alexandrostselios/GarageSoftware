namespace GarageAPI.Models.Service
{
    public class UpdateServiceHistoryNotificationRequest
    {
        public long GarageID { get; set; }

        public long? NotifyDays { get; set; }

        public bool? NotifyNextService { get; set; }
    }
}