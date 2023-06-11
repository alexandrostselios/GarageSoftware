using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using System.Web.Http.Dependencies;
using GarageAPI.Enum;
using GarageAPI.Models.UserModels;
using GarageAPI.Models;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class UserModelsController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public UserModelsController(GarageAPIDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("api/GetUserModels")]
        public async Task<IActionResult> GetUserModels()
        {
            return Ok(await dbContext.UserModels.ToListAsync());
        }

        [HttpGet]
        [Route("api/GetUserModelByUserID/{id:long}")]
        public async Task<IActionResult> GetUserModelByUserID([FromRoute] long id)
        {
            string StoredProc = "exec GetCustomerCars @UserID = " + id;
            List<UserModelsDTO> userModelCars = await dbContext.Output.FromSqlRaw(StoredProc).ToListAsync();
            //List<OutputsController> outt = new OutputsController(dbContext).Getoutput();

            if (userModelCars == null)
            {
                return NotFound();
            }
            return Ok(userModelCars);
        }

        [HttpGet]
        [Route("api/GetUserModelByCarID/{id:long}")]
        public async Task<IActionResult> GetUserModelByUserOrCarID([FromRoute] long id)
        {
            string StoredProc = "exec GetCustomerCar @UserModelID = " + id;
            List<UserModelsDTO> userModelCar = await dbContext.Output.FromSqlRaw(StoredProc).ToListAsync();

            if (userModelCar == null)
            {
                return NotFound();
            }
            return Ok(userModelCar);
        }

        [HttpPost]
        [Route("api/AddUserModel")]
        public async Task<IActionResult> AddUserModel(AddUserModelRequest addUserModelRequest)
        {
            //var temp = dbContext.CarModelManufacturerYear.Where(x => x.CarManufacturer.ID == addUserModelRequest.ModelManufacturer && x.CarModel.ID == addUserModelRequest.Model && x.CarModelYear.ID == addUserModelRequest.ModelYear);
           
            var userModel = new UserModels()
            {
                User = await dbContext.Users.FindAsync(addUserModelRequest.UserID),
                ModelManufacturerYear = dbContext.CarModelManufacturerYear.FirstOrDefault(x => x.CarManufacturer.ID == addUserModelRequest.ModelManufacturer 
                        && x.CarModel.ID == addUserModelRequest.Model
                        && x.CarModelYear.ID == addUserModelRequest.ModelYear),
                LicencePlate = addUserModelRequest.LicencePlate,
                VIN = addUserModelRequest.VIN,
                Color = addUserModelRequest.Color,
                Kilometer = addUserModelRequest.Kilometer,
                CarImage = addUserModelRequest.CarImage
            };
            await dbContext.UserModels.AddAsync(userModel);
            await dbContext.SaveChangesAsync();

            return Ok(userModel);
        }


        [HttpPut]
        [Route("api/UpdateUserModel/{id:long}")]
        public async Task<IActionResult> UpdateUserModelByCarID([FromRoute] long id, UpdateUserModelRequest updateUserModelRequest)
        {
            var userModel = await dbContext.UserModels.FindAsync(id);
            if (userModel != null)
            {
                userModel.Color = updateUserModelRequest.Color;
                userModel.CarImage = updateUserModelRequest.CarImage;
                await dbContext.SaveChangesAsync();
                return Ok(userModel);
            }
            return Ok(userModel);
        }

        [HttpDelete]
        [Route("api/DeleteUserModel/{id:long}")]
        public async Task<IActionResult> DeleteUserModel([FromRoute] long id)
        {
            var userModel = await dbContext.UserModels.FindAsync(id);
            if (userModel != null)
            {
                dbContext.Remove(userModel);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}