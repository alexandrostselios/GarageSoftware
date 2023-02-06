using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GarageAPI.Models.EngineerSpeciality
{
    public class EngineerSpeciality
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Speciality { get; set; }
    }
}