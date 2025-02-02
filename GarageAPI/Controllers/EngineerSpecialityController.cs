using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using GarageAPI.Models.EngineerSpeciality;
using GarageAPI.Models;
using GarageAPI.Models.CarModelYears;
using System.Linq;
using GarageAPI.Models.CarModels;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class EngineerSpecialityController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public EngineerSpecialityController(GarageAPIDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("api/GetEngineerSpeciality")]
        // GET: EngineerSpecialities
        public async Task<IActionResult> GetEngineerSpecialities()
        {
            return Ok((await dbContext.EngineerSpeciality.ToListAsync()).OrderBy(x => x.Speciality));
        }

        [HttpGet]
        [Route("api/GetEngineerSpecialityByID/{id:long}/{garageID:long}")]
        // GET: EngineerSpecialities
        public async Task<IActionResult> GetEngineerSpecialityByID([FromRoute] long id, long garageID)
        {
            return Ok(await dbContext.EngineerSpeciality.FirstOrDefaultAsync(c => c.ID == id && c.GarageID == garageID));
        }

        [HttpPost]
        [Route("api/AddEngineerSpeciality")]
        public async Task<IActionResult> AddEngineerSpeciality(AddEngineerSpecialityRequest addEngineerSpecialityRequest)
        {
            var engineerSpeciality = new EngineerSpeciality()
            {
                GarageID = addEngineerSpecialityRequest.GarageID,
                Speciality = addEngineerSpecialityRequest.Speciality
            };
            await dbContext.EngineerSpeciality.AddAsync(engineerSpeciality);
            await dbContext.SaveChangesAsync();

            return Ok(engineerSpeciality);
        }

        [HttpPost]
        [Route("api/AddEngineerSpecialityList")]
        public async Task<IActionResult> AddEngineerSpecialityList(List<AddEngineerSpecialityRequest> addEngineerSpecialityRequest)
        {
            for (int i = 0; i <= addEngineerSpecialityRequest.Count(); i++)
            {
                var engineerSpeciality = new EngineerSpeciality()
                {
                    Speciality = addEngineerSpecialityRequest[i].Speciality,
                    GarageID = addEngineerSpecialityRequest[i].GarageID
                };
                await dbContext.EngineerSpeciality.AddAsync(engineerSpeciality);
                await dbContext.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/UpdateEngineerSpecialityByID/{id:long}/{garageID:long}")]
        public async Task<IActionResult> UpdateEngineerSpecialityByID([FromRoute] long id, long garageID, UpdateEngineerSpecialityRequest updateEngineerSpecialityRequest)
        {
            var engineerSpeciality = await dbContext.EngineerSpeciality.FirstOrDefaultAsync(c => c.ID == id && c.GarageID == garageID);
            if (engineerSpeciality != null)
            {
                engineerSpeciality.Speciality = updateEngineerSpecialityRequest.Speciality;
                await dbContext.SaveChangesAsync();
                return Ok(engineerSpeciality);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("api/DeleteEngineerSpecialityByID/{id:long}")]
        public async Task<IActionResult> DeleteEngineerSpecialityByID([FromRoute] long id)
        {
            var engineerSpeciality = await dbContext.EngineerSpeciality.FindAsync(id);
            if (engineerSpeciality != null)
            {
                dbContext.Remove(engineerSpeciality);
                await dbContext.SaveChangesAsync();
                return Ok(engineerSpeciality);
            }
            return NotFound();
        }
    }
}