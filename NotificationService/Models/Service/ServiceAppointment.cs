using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageNotificationService.Models.Service
{
    public class ServiceAppointment
    {
        public long ID { get; set; }

        public DateTime ServiceAppointmentDate { get; set; }

        public string ServiceAppointmentComments { get; set; }

        public int ServiceAppointmentStatus { get; set; }

        public long CustomerID { get; set; }

        public string Customer { get; set; }

        public string CustomerEmail { get; set; }

        public string ManufacturerName { get; set; }

        public string ModelName { get; set; }

        public long CustomerCarID { get; set; }

        public string LicencePlate { get; set; }

        public string VIN { get; set; }

        public long Color { get; set; }

        public long Kilometer { get; set; }

    }
}