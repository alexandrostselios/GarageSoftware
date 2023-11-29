using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Models.UserModels;

namespace GarageAPI.Models
{
    [NotMapped]
    public class AddUserModelServiceHistoryRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public long UserModelsID { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ServiceDate { get; set; }

        public long ServiceKilometer { get; set; }

        [ForeignKey("Engineer")]
        public long EngineerID { get; set; }

        public float StartPrice { get; set; }

        public float? DiscountPrice { get; set; }

        public float? DiscountPercentage { get; set; }

        public float FinalPrice { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? StartingTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? StartingDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? FinishingTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? FinishingDate { get; set; }

        public long GarageID { get; set; }

        [NotMapped]
        public List<string> ServiceItemsList { get; set; }
    }
}