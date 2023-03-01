using System.Diagnostics.CodeAnalysis;
using GarageAPI.Models.CarModels;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModelYears;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models
{
    public class CarModelManufacturerYear
    {
        public long ID  { get; set; }

        [ForeignKey("CarManufacturer")]
        public long CarManufacturerID { get; set; }

        [NotNull]
        public CarManufacturer CarManufacturer { get; set; }

        [ForeignKey("CarModel")]
        public long CarModelID { get; set; }

        [NotNull]
        public CarModel CarModel { get; set; }

        [ForeignKey("CarModelYear")]
        public long CarModelYearID { get; set; }

        [NotNull]
        public CarModelYear CarModelYear { get; set; }
    }
 }
