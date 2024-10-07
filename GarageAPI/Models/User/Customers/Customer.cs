using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using GarageAPI.Enum;

namespace GarageAPI.Models.User.Customers
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerID { get; set; }

        public string CustomerSurname { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }

        [ForeignKey("Users")]
        public long UserID { get; set; }

        public byte[]? CustomerPhoto { get; set; }

        public string? CustomerHomePhone { get; set; }

        public string? CustomerMobilePhone { get; set; }

        public string? CustomerComment { get; set; }
    }
}