using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaragePortalNewUI.Models
{
    public class ServiceItems
    {
        public long ID { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }  

        public long GarageID { get; set; }
    }
}