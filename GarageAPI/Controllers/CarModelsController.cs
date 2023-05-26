﻿using GarageAPI.Data;
using GarageAPI.Models.CarModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class CarModelsController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

       public CarModelsController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        

        [HttpGet]
        [Route("api/GetCarModels")]
        public async Task<IActionResult> GetCarModels()
        {
            return Ok(await dbContext.CarModels.ToListAsync());
        }

        [HttpGet]
        [Route("api/GetCarModelsByID/{id:long}")]
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
        [Route("api/AddCarModel")]
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
        [Route("api/UpdateCarModel/{id:long}")]
        public async Task<IActionResult> UpdateCarModel([FromRoute] long id, UpdateCarModelRequest updateCarModelRequest)
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
        [Route("api/DeleteCarModel/{id:long}")]
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