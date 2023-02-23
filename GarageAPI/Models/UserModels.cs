using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Enum;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModelYears;

namespace GarageAPI.Models
{
    public class UserModels
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public Users User { get; set; }

        public CarModelManufacturerYear ModelManufacturerYear { get; set; }

        public CarModelYear ModelYear { get; set; }

        public string? LicencePlate { get; set; }

        public string? VIN { get; set; }

        public long? Color { get; set; }

        public long? Kilometer { get; set; }

        public byte[]? CarImage { get; set; }
    }
}
