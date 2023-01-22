using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Enum;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModelYears;

namespace GarageAPI.Models
{
    public class UserModels
    {
        public long ID { get; set; }

        public Users UserID { get; set; }

        public CarModelManufacturerYear ModelManufacturerYearID { get; set; }

        public CarModelYear ModelYear { get; set; }

        public string? LicencePlate { get; set; }

        public string? VIN { get; set; }

        public long? Color { get; set; }

        public long? Kilometer { get; set; }
    }
}
