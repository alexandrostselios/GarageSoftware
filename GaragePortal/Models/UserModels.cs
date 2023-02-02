using GarageManagementSoftwarePortal.Enum;

namespace GarageManagementSoftwarePortal.Models
{
    public class UserModels
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int ModelManufacturerID { get; set; }

        public int ModelYear { get; set; }

        public string? LicencePlate { get; set; }

        public string? VIN { get; set; }

        public Colors Color { get; set; }

        public long? Kilometer { get; set; }
    }
}
