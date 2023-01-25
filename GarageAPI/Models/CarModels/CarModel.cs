using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.CarModels
{
    public class CarModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string ModelName { get; set; }
    }
}
