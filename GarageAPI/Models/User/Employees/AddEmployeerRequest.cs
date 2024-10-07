using GarageAPI.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.User.Employee
{
    public class AddEmployeeRequest
    {
        public string EmployeeName { get; set; }

        public string EmployeeSurname { get; set; }

        public string EmployeeEmail { get; set; }

        public string EmployeePassword { get; set; }

        public long GarageID { get; set; }

        public UserType UserType { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastLoginDate { get; set; }

        public EnableAccess EnableAccess { get; set; }

        public byte[]? EmployeePhoto { get; set; }

        public string? EmployeeComment { get; set; }

        public string? EmployeeHomePhone { get; set; }

        public string? EmployeeMobilePhone { get; set; }
    }
}
