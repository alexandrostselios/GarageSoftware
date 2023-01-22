using GarageAPI.Data;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModelYears;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class CarModelYearController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public CarModelYearController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        [Route("api/GetCarModelYears")]
        public async Task<IActionResult> GetCarModelYear()
        {
            return Ok(await dbContext.CarModelYear.ToListAsync());
        }

        [HttpGet]
        [Route("api/GetCarModelYearByID/{id:long}")]
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
        [Route("api/AddCarModelYear")]
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
        [Route("api/UpdateCarModelYearByID/{id:long}")]
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
        [Route("api/DeleteCarModelYearByID/{id:long}")]
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
