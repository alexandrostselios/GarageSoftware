namespace GarageAPI.Models.User.Engineers
{
    public class UpdateEngineerLogin
    {
        public long EngineerID { get; set; }

        public long GarageID { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}