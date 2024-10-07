using GarageAPI.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.User.Engineer
{
    public class AddEngineerSpecialitiesRequest
    {
        public long EngineerID { get; set; }

        public long GarageID { get; set; }

        public List<long> EngineerSpecialities { get; set; } // List of EngineerSpeciality IDs
    }
}
