﻿using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace GaragePortalNewUI.Models
{
    public class ServiceHistory
    {
        public long ID { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ServiceDate { get; set; }

        public long ServiceKilometer { get; set; }

        public float StartPrice { get; set; }

        public float FinalPrice { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string LicencePlate { get; set; }

        public string VIN { get; set; }

        public long Color { get; set; }

        public string ModelName { get; set; }

        public string ManufacturerName { get; set; }

        public string ModelYear { get; set; }

        public byte[]? CarImage { get; set; }
    }
}
