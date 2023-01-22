﻿using GarageAPI.Data;
using GarageAPI.Models;
using GarageAPI.Models.CarManufacturers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    [ApiController]
    [Route("api/CarManufacturers")]
    public class CarManufacturerController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public CarManufacturerController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        [Route("GetCarManufacturers")]
        public async Task<IActionResult> GetCarManufacturers()
        {
            return Ok(await dbContext.CarManufacturer.ToListAsync());
        }

        [HttpGet]
        [Route("GetCarManufacturerByID/{id:long}")]
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
        [Route("AddCarManufacturer")]
        public async Task<IActionResult> AddCarManufacturer(AddCarManufacturerRequest addCarManufacturerRequest)
        {
            var carModel = new CarManufacturers()
            {
                ManufacturerName = addCarManufacturerRequest.ManufacturerName
            };
            await dbContext.CarManufacturer.AddAsync(carModel);
            await dbContext.SaveChangesAsync();

            return Ok(carModel);
        }

        [HttpPut]
        [Route("UpdateCarManufacturerByID/{id:long}")]
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
        [Route("DeleteCarManufacturerByID/{id:long}")]
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
