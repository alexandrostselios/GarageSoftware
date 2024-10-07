using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Enum;

namespace GarageAPI.ViewModels
{
    public class UserViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }

        [ForeignKey("Users")]
        public long UserID { get; set; }

        public byte[]? Photo { get; set; }

        public string? HomePhone { get; set; }

        public string? MobilePhone { get; set; }

        public string? Comment { get; set; }

        // Additional properties from Users table
        public long EnableAccess { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastLoginDate { get; set; }
    }
}