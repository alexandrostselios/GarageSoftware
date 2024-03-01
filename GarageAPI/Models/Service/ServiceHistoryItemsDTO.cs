using GarageAPI.Models.UserModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.Service
{
    [NotMapped]
    public class ServiceHistoryItemsDTO
    {
        public long ID { get; set; }

        public long SHID { get; set; }

        public long SIID { get; set; }

        public decimal? Price { get; set; }

        public long GarageID { get; set; }
    }
}
