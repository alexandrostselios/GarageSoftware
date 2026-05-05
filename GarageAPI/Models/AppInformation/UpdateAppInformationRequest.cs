namespace GarageAPI.Models.AppInformation
{
    public class UpdateAppInformationRequest
    {
        public DateTime PublishDate { get; set; }

        public long MajorIncrementalNumber { get; set; }

        public long MinorIncrementalNumber { get; set; }
    }
}