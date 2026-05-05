namespace GaragePortalNewUI.Models.EngineerSpeciality
{
    public class EngineerSpecialitiesResponse
    {
        public long EngineerID { get; set; }
        public string EngineerName { get; set; }
        public string EngineerSurname { get; set; }
        public string EngineerEmail { get; set; }
        public long UserID { get; set; }
        public List<string> Specialities { get; set; }
    }
}