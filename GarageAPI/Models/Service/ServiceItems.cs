using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.Service
{
    public class ServiceItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }
    }
}