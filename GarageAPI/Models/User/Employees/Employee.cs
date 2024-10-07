using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Enum;

namespace GarageAPI.Models.User.Employees
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeID { get; set; }

        public string EmployeeSurname { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeEmail { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }

        [ForeignKey("Users")]
        public long UserID { get; set; }

        public byte[]? EmployeePhoto { get; set; }

        public string? EmployeeHomePhone { get; set; }

        public string? EmployeeMobilePhone { get; set; }

        public string? EmployeeComment { get; set; }
    }
}