using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using GarageAPI.Models;

namespace GarageAPI.Controllers
{
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
            var user = await dbContext.Users.FindAsync(id);
            var userModel = await Task.Run(() => dbContext.UserModels.Where(c => c.User == user).ToList());
            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel);
        }
    }
}