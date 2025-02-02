using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using GaragePortalNewUI.Enum;

namespace GaragePortalNewUI.Models
{
    public class ServiceAppointment
    {
        public long ID { get; set; }

        public long CustomerID { get; set; }

        public long CustomerCarID { get; set; }

        public DateTime ServiceAppointmentDate { get; set; }

        public String ServiceAppointmentComments { get; set; }

        public ServiceAppointmentStatus ServiceAppointmentStatus { get; set; }

        public long GarageID { get; set; }
    }
}