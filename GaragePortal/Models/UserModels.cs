using GaragePortal.Enum;
using System.ComponentModel;

namespace GaragePortal.Models
{
    public class UserModels
    {
        public int ID { get; set; }

        public long  UserID { get; set; }

        [DisplayName("Model Manufacturer")]
        public string ManufacturerName { get; set; }

        [DisplayName("Model Name")]
        public string ModelName { get; set; }

        [DisplayName("Model Year")]
        public string ModelYear { get; set; }

        [DisplayName("Licence Plate")]
        public string? LicencePlate { get; set; }

        [DisplayName("VIN Number")]
        public string? VIN { get; set; }

        public Colors Color { get; set; }

        public long? Kilometer { get; set; }

        [DisplayName("Car Image")]
        public byte[]? CarImage { get; set; }

        [DisplayName("Engine")]
        public string EngineType { get; set; }
    }
}
