using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using GarageAPI.Models.EngineerSpeciality;
using GarageAPI.Models;
using GarageAPI.Models.CarModelYears;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class EngineerSpecialitiesController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public EngineerSpecialitiesController(GarageAPIDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("api/GetEngineerSpecialities")]
        // GET: EngineerSpecialities
        public async Task<IActionResult> GetEngineerSpecialities()
        {
            return Ok(await dbContext.EngineerSpeciality.ToListAsync());
        }

        [HttpGet]
        [Route("api/GetEngineerSpecialityByID/{id:long}")]
        // GET: EngineerSpecialities
        public async Task<IActionResult> GetEngineerSpecialityByID([FromRoute] long id)
        {
            return Ok(await dbContext.EngineerSpeciality.FirstOrDefaultAsync(c => c.ID == id));
        }

        [HttpPost]
        [Route("api/AddEngineerSpeciality")]
        public async Task<IActionResult> AddEngineerSpeciality(AddEngineerSpecialityRequest addEngineerSpecialityRequest)
        {
            var engineerSpeciality = new EngineerSpeciality()
            {
                Speciality = addEngineerSpecialityRequest.Speciality
            };
            await dbContext.EngineerSpeciality.AddAsync(engineerSpeciality);
            await dbContext.SaveChangesAsync();

            return Ok(engineerSpeciality);
        }

        [HttpPut]
        [Route("api/UpdateEngineerSpecialityByID/{id:long}")]
        public async Task<IActionResult> UpdateEngineerSpecialityByID([FromRoute] long id, UpdateEngineerSpecialityRequest updateEngineerSpecialityRequest)
        {
            var engineerSpeciality = await dbContext.EngineerSpeciality.FindAsync(id);
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