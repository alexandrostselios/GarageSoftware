using GaragePortalNewUI.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaragePortalNewUI.Models
{
    public class AddCustomerRequest
    {
        public string CustomerName { get; set; }

        public string CustomerSurname { get; set; }

        public string CustomerEmail { get; set; }

        public string Password { get; set; }

        public long GarageID { get; set; }

        public UserType UserType { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastLoginDate { get; set; }

        public EnableAccess EnableAccess { get; set; }

        public byte[]? CustomerPhoto { get; set; }

        public string? CustomerComment { get; set; }

        public string? CustomerHomePhone { get; set; }

        public string? CustomerMobilePhone { get; set; }
    }
}
