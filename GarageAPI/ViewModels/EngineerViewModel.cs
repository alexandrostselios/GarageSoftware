using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Enum;
using GarageAPI.Models.EngineerSpeciality;

namespace GarageAPI.ViewModels
{
    public class EngineerViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EngineerID { get; set; }

        public string EngineerSurname { get; set; }

        public string EngineerName { get; set; }

        public string EngineerEmail { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }

        [ForeignKey("Users")]
        public long UserID { get; set; }

        public byte[]? EngineerPhoto { get; set; }

        public string? EngineerHomePhone { get; set; }

        public string? EngineerMobilePhone { get; set; }

        public string? EngineerComment { get; set; }

        // Additional properties from Users table
        public long EnableAccess { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastLoginDate { get; set; }

        public long UserType { get; set; }

        public List<EngineerSpeciality>? EngineerSpecialities { get; set; }
    }
}