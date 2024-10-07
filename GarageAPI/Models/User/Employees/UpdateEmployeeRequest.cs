using GarageAPI.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.User.Employee
{
    public class UpdateEmployeeRequest
    {
        public long EmployeeID { get; set; }

        public string EmployeeSurname { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeEmail { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public long GarageID { get; set; }

        public byte[]? EmployeePhoto { get; set; }

        public string? EmployeeHomePhone { get; set; }

        public string? EmployeeMobilePhone { get; set; }

        public string? EmployeeComment { get; set; }

        public long EnableAccess { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}
