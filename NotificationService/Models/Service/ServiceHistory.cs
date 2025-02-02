using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageNotificationService.Models.Service
{
    public class ServiceHistory
    {
        public long ID { get; set; }

        public DateTime? ServiceDate { get; set; }

        public long ServiceKilometer { get; set; }

        public string LicencePlate { get; set; }

        public string ManufacturerName { get; set; }

        public string ModelName { get; set; }

        public long CustomerID { get; set; }

        public string CustomerSurname { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public bool? NotifyNextService { get; set; }
    }
}