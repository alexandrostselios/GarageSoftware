using GarageAPI.Data;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModelYears;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    [ApiController]
    [Route("api/CarModelYear")]
    public class CarModelYearController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public CarModelYearController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        [Route("GetCarModelYear")]
        public async Task<IActionResult> GetCarModelYear()
        {
            return Ok(await dbContext.CarModelYear.ToListAsync());
        }

        [HttpGet]
        [Route("GetCarModelYearByID/{id:long}")]
        public async Task<IActionResult> GetCarModelYear([FromRoute] long id)
        {
            var carModelYear = await dbContext.CarModelYear.FindAsync(id);
            if (carModelYear == null)
            {
                return NotFound();
            }

            return Ok(carModelYear);
        }

        [HttpPost]
        [Route("AddCarModelYear")]
        public async Task<IActionResult> AddCarModelYear(AddCarModelYearRequest addCarModelYearRequest)
        {
            var carModelYear = new CarModelYear()
            {
                Description = addCarModelYearRequest.Description
            };
            await dbContext.CarModelYear.AddAsync(carModelYear);
            await dbContext.SaveChangesAsync();

            return Ok(carModelYear);
        }

        [HttpPut]
        [Route("UpdateCarModelYearByID/{id:long}")]
        public async Task<IActionResult> UpdateCarModelYear([FromRoute] long id, UpdateCarModelYearRequest updateCarModelYearRequest)
        {
            var carModelYear = await dbContext.CarModelYear.FindAsync(id);
            if (carModelYear != null)
            {
                carModelYear.Description = updateCarModelYearRequest.Description;
                await dbContext.SaveChangesAsync();
                return Ok(carModelYear);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteCarModelYearByID/{id:long}")]
        public async Task<IActionResult> DeleteCarModelYearByID([FromRoute] long id)
        {
            var carModelYear = await dbContext.CarModelYear.FindAsync(id);
            if (carModelYear != null)
            {
                dbContext.Remove(carModelYear);
                await dbContext.SaveChangesAsync();
                return Ok(carModelYear);
            }
            return NotFound();
        }
    }
}