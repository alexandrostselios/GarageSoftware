using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Enum;

namespace GarageAPI.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public long? UserType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastLoginDate { get; set; }

        public EnableAccess EnableAccess { get; set; }
    }
}
