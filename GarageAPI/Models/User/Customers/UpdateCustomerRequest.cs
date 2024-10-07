using GarageAPI.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.User.Customers
{
    public class UpdateCustomerRequest
    {
        public long CustomerID { get; set; }

        public string CustomerSurname { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public long GarageID { get; set; }

        public byte[]? CustomerPhoto { get; set; }

        public string? CustomerHomePhone { get; set; }

        public string? CustomerMobilePhone { get; set; }

        public string? CustomerComment { get; set; }

        public long EnableAccess { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}
