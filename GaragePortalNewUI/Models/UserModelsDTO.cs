using GaragePortalNewUI.Enum;
using System.ComponentModel;

namespace GaragePortalNewUI.Models
{
    public class UserModelsDTO
    {
        public int ID { get; set; }

        public long CustomerID { get; set; }

        [DisplayName("Model Manufacturer")]
        public long ModelManufacturer { get; set; }

        [DisplayName("Model Name")]
        public long Model { get; set; }

        [DisplayName("Model Year")]
        public long ModelYear { get; set; }

        [DisplayName("Licence Plate")]
        public string LicencePlate { get; set; }

        [DisplayName("VIN Number")]
        public string VIN { get; set; }

        public Colors Color { get; set; }

        public long? Kilometer { get; set; }

        [DisplayName("Car Image")]
        public byte[]? CarImage { get; set; }

        public long EngineTypeID { get; set; }
    }
}
