using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Models.User;
using GarageAPI.Models.CarModels;
using System.Diagnostics.CodeAnalysis;

namespace GarageAPI.Models
{
    public class Settings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }

        [ForeignKey("Users")]
        public long InsertUserID { get; set; }

        [NotNull]
        public Users InsertUser { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? InsertDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }
    }
}
