using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.CarModels
{
    public class CarModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string ModelName { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }

        public static implicit operator CarModel(List<CarModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
