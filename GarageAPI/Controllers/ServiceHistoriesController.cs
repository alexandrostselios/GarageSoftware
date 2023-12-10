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
using GarageAPI.Models.Service;
using GarageAPI.Enum;
using GarageAPI.Models.User;

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
        public async Task<ActionResult<IEnumerable<ServiceHistoryDTO>>> GetCarServiceHistoryByUserModelsID([FromRoute] long id)
        {
            string StoredProc = "exec GetCarServiceHistory @UserModelsID = " + id;
            List<ServiceHistoryDTO> carServiceHistory = await dbContext.ServiceHistoryDTO.FromSqlRaw(StoredProc).ToListAsync();
            if (carServiceHistory == null)
            {
                return NotFound();
            }
            return Ok(carServiceHistory);
        }

        [HttpGet]
        [Route("api/GetUserModelsServiceHistoryByValue/{searchBy}/{value}/{garageID}")]
        public async Task<ActionResult<IEnumerable<ServiceHistoryDTO>>> GetUserModelsServiceHistoryByValue([FromRoute] int searchBy,string value, long garageID)
        {
            UserModel userModelList = new UserModel();
            if (searchBy == 0)
            {
                userModelList = await dbContext.UserModels.FirstOrDefaultAsync(c => (c.VIN.Contains(value) || c.LicencePlate.Contains(value)));
            }
            else if (searchBy == 1)
            {
                userModelList = await dbContext.UserModels.FirstOrDefaultAsync(c => (c.VIN.Contains(value) ));
            }
            else
            {
                userModelList = await dbContext.UserModels.FirstOrDefaultAsync(c => (c.LicencePlate.Contains(value)));
                
            }
            var userModel = await GetCarServiceHistoryByUserModelsID(userModelList.ID);
            return userModel;
        }

        [HttpGet]
        [Route("api/GetCarServiceHistoryByServiceHistoryID/{id:long}")]
        public async Task<IActionResult> GetCarServiceHistoryByServiceHistoryID([FromRoute] long id)
        {
            string StoredProc = "exec GetCarServiceHistoryByServiceHistoryID @ServiceHistoryID = " + id;
            List<ServiceHistoryWithItemsDTO> carServiceHistory = await dbContext.ServiceHistoryWithItemsDTO.FromSqlRaw(StoredProc).ToListAsync();
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
               isDiscountPercentage = addUserModelServiceHistoryRequest.DiscountPercentage is null ? false : true,
               FinalPrice = addUserModelServiceHistoryRequest.FinalPrice,
               StartingDate = addUserModelServiceHistoryRequest.StartingDate,
               FinishingDate = addUserModelServiceHistoryRequest.FinishingDate,
               GarageID = addUserModelServiceHistoryRequest.GarageID
            };
            await dbContext.ServiceHistory.AddAsync(serviceHistory);
            await dbContext.SaveChangesAsync();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ServiceHistory serviceHistoryGet = await dbContext.ServiceHistory.FirstOrDefaultAsync(x => x.UserModelsID == serviceHistory.UserModelsID &&
                x.GarageID == serviceHistory.GarageID &&
                x.ServiceDate == serviceHistory.ServiceDate &&
                x.Engineer == serviceHistory.Engineer &&
                x.ServiceKilometer == serviceHistory.ServiceKilometer);
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            List<int> serviceHistoryItemsList = addUserModelServiceHistoryRequest.ServiceItemsList.Where(x => int.TryParse(x, out _))
                                                        .Select(int.Parse)
                                                        .ToList();

            for (int i = 0; i < serviceHistoryItemsList.Count; i++)
            {
                ServiceHistoryItems temp = new ServiceHistoryItems()
                {
                    SHID = serviceHistoryGet.ID,
                    SIID = serviceHistoryItemsList[i],
                    GarageID = serviceHistoryGet.GarageID
                };
                await dbContext.ServiceHistoryItems.AddAsync(temp);
                await dbContext.SaveChangesAsync();
            }

            return Ok(serviceHistory);
        }

        [HttpDelete]
        [Route("api/DeleteServiceHistoryByServiceHistoryID/{id:long}")]
        public async Task<IActionResult> DeleteServiceHistoryByServiceHistoryID([FromRoute] long id)
        {
            var serviceHistory = await dbContext.ServiceHistory.FindAsync(id);
            if (serviceHistory != null)
            {
                dbContext.Remove(serviceHistory);
                await dbContext.SaveChangesAsync();
                return Ok(serviceHistory);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("api/DeleteServiceHistoryByUserModelID/{id:long}")]
        public async Task<IActionResult> DeleteServiceHistoryByUserModelID([FromRoute] long id)
        {
            List<ServiceHistory> serviceHistory = await dbContext.ServiceHistory.Where(x=>x.UserModelsID==id).ToListAsync();
            if (serviceHistory != null)
            {
                for(int i = 0; i < serviceHistory.Count; i++)
                {
                    dbContext.Remove(serviceHistory[i]);
                    await dbContext.SaveChangesAsync();
                }
                return Ok(serviceHistory);
            }
            return NotFound();
        }
    }
}