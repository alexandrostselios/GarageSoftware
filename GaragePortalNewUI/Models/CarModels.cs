using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaragePortalNewUI.Models
{
    public class CarModels
    {
        public long ID { get; set; }

        public string ModelName { get; set; }

        public long GarageID { get; set; }
    }
}
