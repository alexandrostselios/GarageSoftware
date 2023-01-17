using GarageAPI.Data;
using GarageAPI.Models.CarModelManufacturerYears;
using GarageAPI.Models.CarModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    [ApiController]
    [Route("api/CarModels")]
    public class CarModelManufacturerYearController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public CarModelManufacturerYearController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        [Route("CarModelManufacturerYear")]
        public async Task<IActionResult> GetarModelManufacturerYear()
        {
            return Ok(await dbContext.CarModelManufacturerYear.ToListAsync());
        }

        [HttpGet]
        [Route("GetCarModelManufacturerYearByID/{id:long}")]
        public async Task<IActionResult> GetCarModelManufacturerYearByID([FromRoute] long id)
        {
            var carModelManufacturerYear = await dbContext.CarModelManufacturerYear.FirstOrDefaultAsync(c => c.ID == id);
            if (carModelManufacturerYear == null)
            {
                return NotFound();
            }

            return Ok(carModelManufacturerYear);
        }

        //[HttpPost]
        //[Route("AddCarModel")]
        //public async Task<IActionResult> AddCarModel(AddCarModelManufacturerYearRequest addCarModelManufacturerYearRequest)
        //{
        //    var carModelManufacturerYear = new CarModelManufacturerYear()
        //    {

        //        CarManufacturer = addCarModelManufacturerYearRequest.
        //    };
        //    await dbContext.CarModels.AddAsync(carModelManufacturerYear);
        //    await dbContext.SaveChangesAsync();

        //    return Ok(carModelManufacturerYear);
        //}
    }
}
