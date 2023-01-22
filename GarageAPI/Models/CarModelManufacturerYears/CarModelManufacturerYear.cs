﻿using System.Diagnostics.CodeAnalysis;
using GarageAPI.Models.CarModels;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModelYears;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using Newtonsoft.Json;

namespace GarageAPI.Models.CarModelManufacturerYears
{
    public class CarModelManufacturerYear
    {
        public long ID { get; set; }

        [ForeignKey("CarManufacturer")]
        public long CarManufacturerID { get; set; }

        public CarManufacturer CarManufacturer { get; set; }

        [ForeignKey("CarModel")]
        public long CarModelID { get; set; }

        public CarModel CarModel { get; set; }

        [ForeignKey("CarModelYear")]
        public long CarModelYearID { get; set; }

        public CarModelYear CarModelYear { get; set; }
    }
}
