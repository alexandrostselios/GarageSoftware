namespace GarageAPI.Models.CarManufacturers
{
    public class AddServiceItemRequest
    {
        public string Description { get; set; }

        public decimal? Price { get; set; }

        public long GarageID { get; set; }
    }
}