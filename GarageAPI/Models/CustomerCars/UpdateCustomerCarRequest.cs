namespace GarageAPI.Models.CustomerCars
{
    public class UpdateCustomerCarRequest
    {
        public long? Color { get; set; }

        public byte[]? CarImage { get; set; }
    }
}
