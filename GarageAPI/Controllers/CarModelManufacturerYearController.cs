using GarageAPI.Data;
using GarageAPI.Models.CarModelManufacturerYears;
using GarageAPI.Models.CarModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class CarModelManufacturerYearController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public CarModelManufacturerYearController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        [Route("api/CarModelManufacturerYear")]
        public async Task<IActionResult> GetCarModelManufacturerYear()
        {
            List<CarModelManufacturerYearDTO> carModelManufacturerYearDTOs = new List<CarModelManufacturerYearDTO>();
            var list = await dbContext.CarModelManufacturerYear.ToListAsync();
            foreach(var i in list)
            {
                carModelManufacturerYearDTOs.Add(new CarModelManufacturerYearDTO{
                    ID = i.ID,
                    CarManufacturerID = i.CarManufacturerID,
                    CarModelID = i.CarModelID,
                    CarModelYearID = i.CarModelYearID,
                });
            }
            return Ok(carModelManufacturerYearDTOs);
        }

        [HttpGet]
        [Route("api/GetCarModelManufacturerYearByID/{id:long}")]
        public async Task<IActionResult> GetCarModelManufacturerYearByID([FromRoute] long id)
        {
            var carModelManufacturerYear = await dbContext.CarModelManufacturerYear.FirstOrDefaultAsync(c => c.ID == id);
            if (carModelManufacturerYear == null)
            {
                return NotFound();
            }
            CarModelManufacturerYearDTO carModelManufacturerYearDTO = new CarModelManufacturerYearDTO
            {
                ID = carModelManufacturerYear.ID,
                CarManufacturerID = carModelManufacturerYear.CarManufacturerID,
                CarModelID = carModelManufacturerYear.CarModelID,
                CarModelYearID = carModelManufacturerYear.CarModelYearID
            };
            return Ok(carModelManufacturerYearDTO);
        }

        [HttpPost]
        [Route("api/AddCarModelManufacturerYear")]
        public async Task<IActionResult> AddCarModelManufacturerYear(AddCarModelManufacturerYearRequest addCarModelManufacturerYearRequest)
        {
            var carModelManufacturerYear = new CarModelManufacturerYear()
            {
                CarModelID = addCarModelManufacturerYearRequest.CarModelID,
                CarManufacturerID = addCarModelManufacturerYearRequest.CarManufacturerID,
                CarModelYearID = addCarModelManufacturerYearRequest.CarModelYearID,
            };
            await dbContext.CarModelManufacturerYear.AddAsync(carModelManufacturerYear);
            await dbContext.SaveChangesAsync();
            return Ok(carModelManufacturerYear);
        }
    }
}
