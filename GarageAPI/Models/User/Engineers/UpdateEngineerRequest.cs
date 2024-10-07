using GarageAPI.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.User.Engineers
{
    public class UpdateEngineerRequest
    {
        public long EngineerID { get; set; }

        public string EngineerSurname { get; set; }

        public string EngineerName { get; set; }

        public string EngineerEmail { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public long GarageID { get; set; }

        public byte[]? EngineerPhoto { get; set; }

        public string? EngineerHomePhone { get; set; }

        public string? EngineerMobilePhone { get; set; }

        public string? EngineerComment { get; set; }

        public string? EngineerPassword { get; set; }

        public long EnableAccess { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public List<long>? EngineerSpecialitiesID { get; set; }
    }
}
