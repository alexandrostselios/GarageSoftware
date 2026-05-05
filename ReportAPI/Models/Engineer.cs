using GaragePortalNewUI.Models.EngineerSpeciality;
using ReportAPI.Enum;

namespace ReportAPI.Models
{
    public class Engineer
    {
        public long? EngineerID { get; set; }

        public string EngineerSurname { get; set; }

        public string EngineerName { get; set; }

        public string EngineerEmail { get; set; }

        public string EngineerPassword { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public long GarageID { get; set; }

        public UserType UserType { get; set; }

        public EnableAccess EnableAccess { get; set; }

        public long? UserID { get; set; }

        public byte[] EngineerPhoto { get; set; }

        public string? EngineerHomePhone { get; set; }

        public string? EngineerMobilePhone { get; set; }

        public string? EngineerComment { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public List<long>? EngineerSpecialitiesID { get; set; }

        public List<EngineerSpeciality>? EngineerSpecialities { get; set; }
    }
}