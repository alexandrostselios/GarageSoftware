using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models
{
    public class GarageDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Description { get; set; }

        public bool isActive { get; set; }

        public string Domain { get; set; }

        //public string? Country { get; set; }

        //public string? Address { get; set; }

        //public string? ZipCode { get; set; }

        //public string? City { get; set; }
    }
}