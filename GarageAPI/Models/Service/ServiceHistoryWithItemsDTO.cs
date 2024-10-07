using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.Service
{
    [NotMapped]
    public class ServiceHistoryWithItemsDTO
    {
        public long ID { get; set; }
        public long CustomerCarID { get; set; }

        public string? Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ServiceDate { get; set; }

        public long? ServiceKilometer { get; set; }

        public float? StartPrice { get; set; }

        public float? FinalPrice { get; set; }

        public string? EngineerName { get; set; }

        public string? EngineerSurname { get; set; }

        public string LicencePlate { get; set; }

        public string VIN { get; set; }

        public long Color { get; set; }

        public long GarageID { get; set; }

        public string EngineType { get; set; }

        public string ModelName { get; set; }

        public string ManufacturerName { get; set; }

        public string ModelYear { get; set; }

        public byte[]? CarImage { get; set; }

        public long EngineerID { get; set; }

        [NotMapped]
        public string? Engineer { get; set; }

        public long? ServiceItemID { get; set; }

        public string? ServiceItemDescription { get; set; }

        public decimal? ServiceItemPrice { get; set; }

        public float? DiscountPrice { get; set; }

        public float? DiscountPercentage { get; set; }

        public bool isDiscountPercentage { get; set; }
    }
}