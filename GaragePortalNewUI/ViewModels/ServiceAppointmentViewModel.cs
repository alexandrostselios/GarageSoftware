using GaragePortalNewUI.Enum;
using System;

namespace GaragePortalNewUI.ViewModels
{
    public class ServiceAppointmentViewModel
    {
        public long ID { get; set; }

        public DateTime ServiceAppointmentDate { get; set; }

        public string ServiceAppointmentComments { get; set; }

        public ServiceAppointmentStatus ServiceAppointmentStatus { get; set; }

        public long CustomerID { get; set; }

        public long CustomerCarID { get; set; }

        public string Customer { get; set; }

        public string ManufacturerName { get; set; }

        public string ModelName { get; set; }

        public string LicencePlate { get; set; }

        public string VIN { get; set; }

        public Colors Color { get; set; }

        public long? Kilometer { get; set; }

        public long GarageID { get; set; }
    }
}