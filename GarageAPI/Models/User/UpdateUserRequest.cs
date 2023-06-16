using GarageAPI.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.User
{
    public class UpdateUserRequest
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public long? GarageID { get; set; }

        public UserType? UserType { get; set; }

        public long? EngineerSpeciality { get; set; }

        public EnableAccess EnableAccess { get; set; }

        public byte[]? UserPhoto { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}
