using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models
{
    public class GarageDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Description { get; set; }

        public bool isActive { get; set; }
    }
}
