using GarageAPI.Data;
using GarageAPI.Models.CarModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace GarageAPI.Controllers
{
    [ApiController]
    [Route("api/CarModels")]
    public class CarModelsController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

       public CarModelsController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        

        [HttpGet]
        [Route("GetCarModels")]
        public async Task<IActionResult> GetCarModels()
        {
            return Ok(await dbContext.CarModels.ToListAsync());

        }

        [HttpGet]
        [Route("GetCarModelsByID/{id:long}")]
        public async Task<IActionResult> GetCarModel([FromRoute] long id)
        {
            var carModel = await dbContext.CarModels.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }

            return Ok(carModel);
        }

        [HttpPost]
        [Route("AddCarModel")]
        public async Task<IActionResult> AddCarModel(AddCarModelRequest addCarModelRequest)
        {
            var carModel = new CarModel()
            {
                
                ModelName = addCarModelRequest.ModelName
            };
            await dbContext.CarModels.AddAsync(carModel);
            await dbContext.SaveChangesAsync();

            return Ok(carModel);
        }

        [HttpPut]
        [Route("UpdateCarModel/{id:long}")]
        public async Task<IActionResult> UpdateCarModel([FromRoute] long id, UpdateCarModelYearRequest updateCarModelRequest)
        {
            var carModel = await dbContext.CarModels.FindAsync(id);
            if(carModel != null)
            {
                carModel.ModelName = updateCarModelRequest.ModelName;
                await dbContext.SaveChangesAsync();
                return Ok(carModel);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteCarModel/{id:long}")]
        public async Task<IActionResult> DeleteCarModel([FromRoute] long id)
        {
            var carModel = await dbContext.CarModels.FindAsync(id);
            if (carModel != null)
            {
                dbContext.Remove(carModel);
                await dbContext.SaveChangesAsync();
                return Ok(carModel);
            }

            return NotFound();
        }
    }
}
