using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaragePortalNewUI.Models
{
    public class CarFuelType
    {
        public long ID { get; set; }

        public string FuelType { get; set; }

        public long GarageID { get; set; }
    }
}
