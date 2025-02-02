namespace GarageAPI.Models.User.Engineers
{
    public class UpdateEmployeeLogin
    {
        public long EmployeeID { get; set; }

        public long GarageID { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}