using GarageAPI.Data;
using GarageAPI.Models;
using GarageAPI.Models.CarManufacturers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class CarManufacturerController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public CarManufacturerController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/GetCarManufacturers")]
        public async Task<IActionResult> GetCarManufacturers()
        {
            return Ok(await dbContext.CarManufacturer.ToListAsync());
        }

        /* TEST */
        [HttpGet]
        [Route("api/GetCarManufacturersToList")]
        public Task<IActionResult> GetCarManufacturersToList()
        {
            List<CarManufacturer> modelManufacturer = dbContext.CarManufacturer.ToList();
            return Task.FromResult<IActionResult>(Ok(modelManufacturer));
        }
        /* TEST*/

        [HttpGet]
        [Route("api/GetCarManufacturerByID/{id:long}")]
        public async Task<IActionResult> GetCarManufacturer([FromRoute] long id)
        {
            var carModel = await dbContext.CarManufacturer.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }
            return Ok(carModel);
        }


        [HttpPost]
        [Route("api/AddCarManufacturer")]
        public async Task<IActionResult> AddCarManufacturer(AddCarManufacturerRequest addCarManufacturerRequest)
        {
            var carModel = new CarManufacturer()
            {
                ManufacturerName = addCarManufacturerRequest.ManufacturerName
            };
            await dbContext.CarManufacturer.AddAsync(carModel);
            await dbContext.SaveChangesAsync();

            return Ok(carModel);
        }

        [HttpPut]
        [Route("api/UpdateCarManufacturerByID/{id:long}")]
        public async Task<IActionResult> UpdateCarManufacturer([FromRoute] long id, UpdateCarManufacturerRequest updateCarManufacturerRequest)
        {
            var carManufacturer = await dbContext.CarManufacturer.FindAsync(id);
            if (carManufacturer != null)
            {
                carManufacturer.ManufacturerName = updateCarManufacturerRequest.ManufacturerName;
                await dbContext.SaveChangesAsync();
                return Ok(carManufacturer);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("api/DeleteCarManufacturerByID/{id:long}")]
        public async Task<IActionResult> DeleteCarManufacturer([FromRoute] long id)
        {
            var carManufacturer = await dbContext.CarManufacturer.FindAsync(id);
            if (carManufacturer != null)
            {
                dbContext.Remove(carManufacturer);
                await dbContext.SaveChangesAsync();
                return Ok(carManufacturer);
            }
            return NotFound();
        }
    }
}
