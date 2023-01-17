using System.Diagnostics.CodeAnalysis;
using GarageAPI.Models.CarModels;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModelYears;

namespace GarageAPI.Models.CarModelManufacturerYears
{
    public class CarModelManufacturerYear
    {
        public long ID { get; set; }

        [NotNull]
        public CarManufacturer CarManufacturer { get; set; }

        [NotNull]
        public CarModel CarModel { get; set; }

        [NotNull]
        public CarModelYear CarModelYear { get; set; }
    }
}
