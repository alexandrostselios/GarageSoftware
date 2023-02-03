
using GaragePortal.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagementSoftwarePortal.Models
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

        public string? LicencePlate { get; set; }

        public string? VIN { get; set; }

        public Colors Color { get; set; }

        public long? Kilometer { get; set; }

    }
}