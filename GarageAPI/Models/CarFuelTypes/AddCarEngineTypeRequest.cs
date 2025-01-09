using GarageAPI.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.CarEngineTypes
{
    public class AddCarEngineTypeRequest
    {
        public string? EngineType { get; set; }

        public long GarageID { get; set; }

    }
}