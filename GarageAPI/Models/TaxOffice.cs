using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models
{
    public class TaxOffice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long ID { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }
    }
}
