using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Models.CarEngineTypes;
using GarageAPI.Models.User.Customers; // Add the namespace import for Customers


namespace GarageAPI.Models.CustomerCars
{
    public class CustomerCar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public Customer Customer { get; set; }

        public CarModelManufacturerYear ModelManufacturerYear { get; set; }

        public CarFuelType EngineType { get; set; }

        public string? LicencePlate { get; set; }

        public string? VIN { get; set; }

        public long? Color { get; set; }

        public long? Kilometer { get; set; }

        public byte[]? CarImage { get; set; }

        public long GarageID { get; set; }
    }
}
