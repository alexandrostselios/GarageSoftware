
using GaragePortalNewUI.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaragePortalNewUI.Models
{
    public class CustomerCars
    {
        public long id { get; set; }

        public long UserID { get; set; }

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

    }
}