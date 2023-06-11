using GarageAPI.Data;
using GarageAPI.Models.CarModels;
using GarageAPI.Models.CarModelYears;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class CarModelManufacturerYear : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public CarModelManufacturerYear(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/GetCarModelManufacturerYear")]
        public async Task<IActionResult> GetCarModelManufacturerYear()
        {
            return Ok(await dbContext.CarModelManufacturerYear.ToListAsync());
        }

        [HttpGet]
        [Route("api/GetCarModelManufacturerYear/{id:long}")]
        public async Task<IActionResult> GetCarModelManufacturerYear([FromRoute] long id)
        {
            var carModelManufacturerYear = await dbContext.CarModelManufacturerYear.FindAsync(id);
            if (carModelManufacturerYear == null)
            {
                return NotFound();
            }
            return Ok(carModelManufacturerYear);
        }

        [HttpGet]
        [Route("api/GetCarModelManufacturerYearByManufacturerID/{manufacturerID:long}")]
        public async Task<IActionResult> GetCarModelManufacturerYearByManufacturerID([FromRoute] long manufacturerID)
        {
            var carModelManufacturerYear = await dbContext.CarModelManufacturerYear.Where(c => c.CarManufacturerID == manufacturerID).ToListAsync();
            List<CarModel> carModelsList = new List<CarModel>();
            for (int i = 0; i < carModelManufacturerYear.Count; i++)
            {
                carModelsList.Add(await dbContext.CarModels.Where(x => x.ID == carModelManufacturerYear[i].CarModelID).FirstOrDefaultAsync());
            } 
            if (carModelManufacturerYear == null)
            {
                return NotFound();
            }
            return Ok(carModelsList.Distinct().OrderBy(x => x.ModelName));
        }

        [HttpGet]
        [Route("api/GetCarModelManufacturerYearByModelID/{modelID:long}")]
        public async Task<IActionResult> GetCarModelManufacturerYearByModelID([FromRoute] long modelID)
        {
            var carModelManufacturerYear = await dbContext.CarModelManufacturerYear.Where(c => c.CarModelID == modelID).ToListAsync();
            List<CarModelYear> carModelYearList = new List<CarModelYear>();
            for (int i = 0; i < carModelManufacturerYear.Count; i++)
            {
                carModelYearList.Add(await dbContext.CarModelYear.Where(x => x.ID == carModelManufacturerYear[i].CarModelYearID).FirstOrDefaultAsync());
            }
            if (carModelManufacturerYear == null)
            {
                return NotFound();
            }
            return Ok(carModelYearList.Distinct().OrderBy(x => x.ID));
        }
    }
}