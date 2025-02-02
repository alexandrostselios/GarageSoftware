namespace GarageAPI.Models.User.Customers
{
    public class UpdateCustomerLogin
    {
        public long CustomerID { get; set; }

        public long GarageID { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}