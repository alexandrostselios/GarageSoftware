using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Models.User;
using GarageAPI.Models.UserModels;
using GarageAPI.Models.CarModels;
using System.Diagnostics.CodeAnalysis;

namespace GarageAPI.Models
{
    public class Report
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Definition { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? InsertDate { get; set; }
    }
}
