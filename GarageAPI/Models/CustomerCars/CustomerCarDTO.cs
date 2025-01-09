using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.CustomerCars
{
    public class CustomerCarDTO
    {
        public long ID { get; set; }

        public long CustomerID { get; set; }

        public string ManufacturerName { get; set; }

        public string ModelName { get; set; }

        public string ModelYear { get; set; }

        public string LicencePlate { get; set; }

        public string VIN { get; set; }

        public long Color { get; set; }

        public long Kilometer { get; set; }      

        public byte[]? CarImage { get; set; }

        public string FuelType {get; set; }

    }
}