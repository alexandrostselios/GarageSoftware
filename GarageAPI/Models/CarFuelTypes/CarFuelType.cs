using GarageAPI.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.CarEngineTypes
{
    public class CarFuelType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public String FuelType { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }
    }
}
