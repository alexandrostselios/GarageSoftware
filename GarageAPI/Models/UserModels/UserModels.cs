using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Enum;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModelYears;
using GarageAPI.Models.CarEngineTypes;
using GarageAPI.Models.User;

namespace GarageAPI.Models.UserModels
{
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public Users User { get; set; }

        public CarModelManufacturerYear ModelManufacturerYear { get; set; }

        public CarEngineType EngineType { get; set; }

        public string? LicencePlate { get; set; }

        public string? VIN { get; set; }

        public long? Color { get; set; }

        public long? Kilometer { get; set; }

        public byte[]? CarImage { get; set; }

        public long GarageID { get; set; }
    }
}
