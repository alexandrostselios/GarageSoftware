using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using GarageAPI.Models;
using System.Web.Http.Dependencies;

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
            List<Output> userModelCars = await dbContext.Output.FromSqlRaw(StoredProc).ToListAsync();
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
            List<Output> userModelCar = await dbContext.Output.FromSqlRaw(StoredProc).ToListAsync();

            if (userModelCar == null)
            {
                return NotFound();
            }
            return Ok(userModelCar);
        }
    }
}