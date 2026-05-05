using ReportAPI.Enum;

namespace ReportAPI.Models
{
    public class Customer
    {
        public long CustomerID { get; set; }

        public string CustomerSurname { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public long GarageID { get; set; }

        public long UserID { get; set; }

        public byte[]? CustomerPhoto { get; set; }

        public string? CustomerHomePhone { get; set; }

        public string? CustomerMobilePhone { get; set; }

        public string CustomerComment { get; set; }

        public string CustomerPassword { get; set; }

        // Additional properties from Users table
        public EnableAccess EnableAccess { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public UserType UserType { get; set; }
    }
}
