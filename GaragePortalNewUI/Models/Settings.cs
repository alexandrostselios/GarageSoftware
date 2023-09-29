using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GaragePortalNewUI.Models
{
    public class Settings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

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
