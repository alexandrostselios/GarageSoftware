using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models
{
    public class ServiceHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public UserModels UserModels { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ServiceDate { get; set; }

        public long ServiceKilometer { get; set; }

        public Users Engineer { get; set; }
        
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
