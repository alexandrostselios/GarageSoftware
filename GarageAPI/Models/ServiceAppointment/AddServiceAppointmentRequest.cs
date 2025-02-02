using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GarageAPI.Models.ServiceAppointment
{
    public class AddServiceAppointmentRequest
    {
        public DateTime ServiceAppointmentDate { get; set; }

        public string ServiceAppointmentComments { get; set; }

        public ServiceAppointmentStatus ServiceAppointmentStatus { get; set; }

        public long CustomerID { get; set; }

        public long CustomerCarID { get; set; }

        public long Kilometer { get; set; }

        public long GarageID { get; set; }
    }
}
