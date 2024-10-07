using GarageAPI.Data;
using GarageAPI.Enum;
using GarageAPI.Models.CarEngineTypes;
using GarageAPI.Models.CarManufacturers;
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
        [Route("api/GetCarEngineTypesToList")]
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

        [HttpPost]
        [Route("api/AddCarEngineType")]
        public async Task<IActionResult> AddCarEngineType(AddCarEngineTypeRequest addCarEngineTypeRequest)
        {
            var carEngineType = new CarEngineType()
            {
               EngineType = addCarEngineTypeRequest.EngineType,
               GarageID = addCarEngineTypeRequest.GarageID
            };
            await dbContext.CarEngineType.AddAsync(carEngineType);
            await dbContext.SaveChangesAsync();

            return Ok(carEngineType);
        }

        [HttpPut]
        [Route("api/UpdateCarEngineType/{engineTypeID:long}/{garageID:long}")]
        public async Task<IActionResult> UpdateUser([FromRoute] long engineTypeID, long garageID, [FromBody] UpdateCarEngineTypeRequest updateCarEngineTypeRequest)
        {
            var carEngineType = await dbContext.CarEngineType.FirstOrDefaultAsync(x => x.ID == engineTypeID && x.GarageID == garageID);
            if (carEngineType != null)
            {
                carEngineType.EngineType = updateCarEngineTypeRequest.EngineType;

                await dbContext.SaveChangesAsync();
                return Ok(carEngineType);
            }
            return NotFound();
        }
        
        [HttpDelete]
        [Route("api/DeleteCarEngineTypeByID/{engineID:long}/{garageID:long}")]
        public async Task<IActionResult> DeleteCarEngineTypeByID([FromRoute] long engineID, long garageID)
        {
            var carEngineType = await dbContext.CarEngineType.FirstOrDefaultAsync(x => x.ID == engineID && x.GarageID == garageID);

            if (carEngineType != null)
            {
                // Check if the CarEngineType ID is used in the related table
                var isCarEngineTypeUsed = await dbContext.CustomerCars.FirstOrDefaultAsync(x => x.EngineType.ID == engineID && x.GarageID == garageID);

                if (isCarEngineTypeUsed is not null)
                {
                    // CarEngineType ID is used in the related table, so deletion is not allowed
                    return BadRequest("Deletion is not allowed because this CarEngineType is used in other records.");
                }

                dbContext.Remove(carEngineType);
                await dbContext.SaveChangesAsync();
                return Ok(carEngineType);
            }
            return NotFound();
        }
    }
}