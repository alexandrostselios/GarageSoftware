﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models
{
    [NotMapped]
    public class Output
    {
        public long id { get; set; }
        public long UserID { get; set; }
        public string LicencePlate { get; set; }
        public string VIN { get; set; }
        public long Color { get; set; }
        public long Kilometer { get; set; }
        public string ModelName { get; set; }
        public string ManufacturerName { get; set; }
    }
}