using GarageAPI.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.User.Engineer
{
    public class AddEngineerRequest
    {
        public long? EngineerID { get; set; }

        public string EngineerSurname { get; set; }

        public string EngineerName { get; set; }

        public string EngineerEmail { get; set; }

        public string EngineerPassword { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastLoginDate { get; set; }

        public long GarageID { get; set; }

        public UserType UserType { get; set; }

        public EnableAccess EnableAccess { get; set; }

        public byte[]? UserPhoto { get; set; }


        public string? EngineerHomePhone { get; set; }

        public string? EngineerMobilePhone { get; set; }

        public string? EngineerComment { get; set; }

        public List<long>? EngineerSpecialities { get; set; } // List of EngineerSpeciality IDs
    }
}
