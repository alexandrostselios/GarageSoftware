using System.Diagnostics.CodeAnalysis;
using GarageAPI.Models.CarModels;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModelYears;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace GarageAPI.Models.CarModelManufacturerYears
{
    [NotMapped]
    public class CarModelManufacturerYearDTO
    {
        public long ID { get; set; }

        public long CarManufacturerID { get; set; }

        public long CarModelID { get; set; }

        public long CarModelYearID { get; set; }
    }
}
