using GaragePortalNewUI.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaragePortalNewUI.ViewModels
{
    public class UpdateServiceAppointmentViewModel
    {
        public long ID { get; set; }

        public DateTime ServiceAppointmentDate { get; set; }

        public string ServiceAppointmentComments { get; set; }

        public ServiceAppointmentStatus ServiceAppointmentStatus { get; set; }

        public long Kilometer { get; set; }

        public long GarageID { get; set; }

        public long? Menu { get; set; }
    }
}