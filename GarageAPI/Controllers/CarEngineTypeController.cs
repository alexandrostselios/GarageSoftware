using GarageAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    public class CarEngineTypeController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public CarEngineTypeController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/GetCarEngineType")]
        public async Task<IActionResult> GetCarEngineType()
        {
            return Ok(await dbContext.CarEngineType.ToListAsync());
        }

        [HttpGet]
        [Route("api/GetCarEngineTypeByID/{id:long}")]
        public async Task<IActionResult> GetCarEngineType([FromRoute] long id)
        {
            var carEngine = await dbContext.CarEngineType.FindAsync(id);
            if (carEngine == null)
            {
                return NotFound();
            }
            return Ok(carEngine);
        }
    }
}