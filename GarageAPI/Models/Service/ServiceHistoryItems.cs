using GarageAPI.Models.UserModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.Service
{
    public class ServiceHistoryItems
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [ForeignKey("ServiceHistory")]
        public long SHID { get; set; }

        public ServiceHistory ServiceHistory { get; set; }

        [ForeignKey("ServiceItems")]
        public long SIID { get; set; }

        public ServiceItems ServiceItems { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }

        public decimal? Price { get; set; }

        public GarageDetails GarageDetails { get; set; }
    }
}
