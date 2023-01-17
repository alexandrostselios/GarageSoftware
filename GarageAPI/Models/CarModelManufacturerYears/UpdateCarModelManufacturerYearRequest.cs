using GarageAPI.Models.CarModels;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModelYears;
namespace GarageAPI.Models.CarModelManufacturerYears
{
    public class UpdateCarModelManufacturerYearRequest
    {
        public CarModel CarModelID { get; set; }

        public CarManufacturer CarManufacturerID { get; set; }

        public CarModelYear CarModelYearID { get; set; }
    }
}
