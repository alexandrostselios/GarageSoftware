using System.ComponentModel.DataAnnotations.Schema;

namespace GaragePortalNewUI.Models
{
    public class CarModel
    {
        public long ID { get; set; }

        public string ModelName { get; set; }

        public long GarageID { get; set; }

    }
}
