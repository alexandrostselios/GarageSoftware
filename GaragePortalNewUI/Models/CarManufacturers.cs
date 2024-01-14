using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaragePortalNewUI.Models
{
    public class CarManufacturers
    {
        public long ID { get; set; }

        public string ManufacturerName { get; set; }

        public long GarageID { get; set; }
    }
}
