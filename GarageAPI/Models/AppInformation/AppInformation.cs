using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.AppInformation
{
    public class AppInformation
    {
        public int ID { get; set; }
        // Foreign Key Reference
        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }
        public DateTime PublishDate { get; set; }
        public long MajorIncrementalNumber { get; set; }
        public long MinorIncrementalNumber { get; set; }
    }
}