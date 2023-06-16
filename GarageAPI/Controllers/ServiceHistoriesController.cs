using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using GarageAPI.Models.UserModels;
using GarageAPI.Models;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class ServiceHistoriesController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public ServiceHistoriesController(GarageAPIDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("api/GetServiceHistory")]
        public async Task<IActionResult> GetServiceHistory()
        {
            return Ok(await dbContext.ServiceHistory.ToListAsync());
        }

        [HttpGet]
        [Route("api/GetCarServiceHistoryByUserModelsID/{id:long}")]
        public async Task<IActionResult> GetUserModelByUserID([FromRoute] long id)
        {
            string StoredProc = "exec GetCarServiceHistory @UserModelsID = " + id;
            List<ServiceHistoryDTO> carServiceHistory = await dbContext.ServiceHistoryDTO.FromSqlRaw(StoredProc).ToListAsync();
            if (carServiceHistory == null)
            {
                return NotFound();
            }
            return Ok(carServiceHistory);
        }

        [HttpPost]
        [Route("api/AddUserModelServiceHistory")]
        public async Task<IActionResult> AddUserModelServiceHistory(AddUserModelServiceHistoryRequest addUserModelServiceHistoryRequest)
        {
            var serviceHistory = new ServiceHistory()
            {
               UserModels = await dbContext.UserModels.FindAsync(addUserModelServiceHistoryRequest.UserModelsID),
               ServiceDate = addUserModelServiceHistoryRequest.ServiceDate,
               Description = addUserModelServiceHistoryRequest.Description,
               ServiceKilometer = addUserModelServiceHistoryRequest.ServiceKilometer,
               Engineer = await dbContext.Users.FindAsync(addUserModelServiceHistoryRequest.EngineerID),
               StartPrice = addUserModelServiceHistoryRequest.StartPrice,
               DiscountPrice = addUserModelServiceHistoryRequest.DiscountPrice,
               DiscountPercentage = addUserModelServiceHistoryRequest.DiscountPercentage,
               FinalPrice = addUserModelServiceHistoryRequest.FinalPrice,
               StartingDate = addUserModelServiceHistoryRequest.StartingDate,
               FinishingDate = addUserModelServiceHistoryRequest.FinishingDate
            };
            await dbContext.ServiceHistory.AddAsync(serviceHistory);
            await dbContext.SaveChangesAsync();

            return Ok(serviceHistory);
        }
    }
}
