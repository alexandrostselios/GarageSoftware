using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GarageAPI.Models.EngineerSpecialities
{
    public class EngineerSpecialities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [ForeignKey("Engineer")]
        public long EngineerID { get; set; }

        [ForeignKey("EngineerSpeciality")]
        public long SpecialityID { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }
    }
}