using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace GaragePortalNewUI.Models.AppInformation
{
    public class AppInformation
    {
        public int ID { get; set; }
        public long GarageID { get; set; }
        public DateTime PublishDate { get; set; }
        public long MajorIncrementalNumber { get; set; }
        public long MinorIncrementalNumber { get; set; }
    }
}
