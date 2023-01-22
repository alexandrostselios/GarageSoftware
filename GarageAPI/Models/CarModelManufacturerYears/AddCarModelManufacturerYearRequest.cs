using GarageAPI.Models.CarModels;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModelYears;
namespace GarageAPI.Models.CarModelManufacturerYears
{
    public class AddCarModelManufacturerYearRequest
    {
        public long CarModelID { get; set; }

        public long CarManufacturerID { get; set; }

        public long CarModelYearID { get; set; }
    }
}
