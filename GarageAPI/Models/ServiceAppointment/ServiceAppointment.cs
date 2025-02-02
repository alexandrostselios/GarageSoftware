using GarageAPI.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.ServiceAppointment
{
    public class ServiceAppointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [ForeignKey("Customer")]
        public long CustomerID { get; set; }

        [ForeignKey("CustomerCars")]
        public long CustomerCarID { get; set; }

        public DateTime ServiceAppointmentDate { get; set; }

        public String ServiceAppointmentComments { get; set; }

        public ServiceAppointmentStatus ServiceAppointmentStatus { get; set; }

        public long Kilometer { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }
    }
}