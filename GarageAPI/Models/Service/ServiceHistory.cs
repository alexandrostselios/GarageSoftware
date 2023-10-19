using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Models.User;
using GarageAPI.Models.UserModels;

namespace GarageAPI.Models.Service
{
    public class ServiceHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [ForeignKey("UserModels")]
        public long UserModelsID { get; set; }

        public UserModel UserModels { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ServiceDate { get; set; }

        public long ServiceKilometer { get; set; }

        [ForeignKey("Engineer")]
        public long EngineerID { get; set; }

        public Users Engineer { get; set; }

        public float StartPrice { get; set; }

        public float? DiscountPrice { get; set; }

        public float? DiscountPercentage { get; set; }

        public float FinalPrice { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? StartingDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? FinishingDate { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }
    }
}
