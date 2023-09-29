using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaragePortalNewUI.Models
{
    public class ServiceHistoryDTO
    {
        public long UserModelsID { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ServiceDate { get; set; }

        public long ServiceKilometer { get; set; }

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
    }
}