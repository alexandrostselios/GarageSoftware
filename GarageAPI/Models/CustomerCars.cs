using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarageAPI.Models
{
    [NotMapped]
    public partial class CustomerCars
    {
        public long id { get; set; }

        public long UserID { get; set; }

        public string ManufacturerDescription { get; set; }

        public long ModelID { get; set; }

        public string ModelDescription { get; set; }

        public string ModelYear { get; set; }

        public string? LicencePlate { get; set; }

        public string? VIN { get; set; }

        public long? Color { get; set; }

        public long? Kilometer { get; set; }


        //public virtual ModelManufacturer ModelManufacturer { get; set; }

        //public virtual Users Users { get; set; }
    }
}
