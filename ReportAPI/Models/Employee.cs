using GaragePortalNewUI.Models.EngineerSpeciality;
using ReportAPI.Enum;

namespace ReportAPI.Models
{
    public class Employee
    {
        public long EmployeeID { get; set; }

        public string EmployeeSurname { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeEmail { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public long GarageID { get; set; }

        public long UserID { get; set; }

        public byte[]? EmployeePhoto { get; set; }

        public string? EmployeeHomePhone { get; set; }

        public string? EmployeeMobilePhone { get; set; }

        public string EmployeeComment { get; set; }

        public string EmployeePassword { get; set; }

        // Additional properties from Users table
        public EnableAccess EnableAccess { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public UserType UserType { get; set; }
    }
}