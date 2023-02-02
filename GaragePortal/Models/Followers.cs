using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GarageManagementSoftwarePortal.Models
{
    public class Followers
    {
        [Key]
        public long ID { get; set; }

        public Users User1 { get; set; }

        public Users User2 { get; set; }

        [Display(Name = "Date of Connection")]
        public DateTime DateOfConnection { get; set; }

    }
}