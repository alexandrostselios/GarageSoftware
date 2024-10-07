using System.ComponentModel.DataAnnotations.Schema;

namespace GaragePortalNewUI.Models
{
    public class CarModelViewModel
    {
        public long ID { get; set; }

        public string ModelName { get; set; }

        public long GarageID { get; set; }

    }
}
