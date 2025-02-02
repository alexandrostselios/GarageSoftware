using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GarageAPI.Models.ServiceAppointment
{
    public class UpdateServiceAppointmentRequest
    {
        public long ID { get; set; }

        public DateTime ServiceAppointmentDate { get; set; }

        public string ServiceAppointmentComments { get; set; }

        public ServiceAppointmentStatus ServiceAppointmentStatus { get; set; }

        public long Kilometer { get; set; }

        public long GarageID { get; set; }
    }
}