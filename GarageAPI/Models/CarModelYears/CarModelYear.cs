using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.CarModelYears
{
    public class CarModelYear
    {
        public long ID { get; set; }

        public string Description { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }
    }
}
