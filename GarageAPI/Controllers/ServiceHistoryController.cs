using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using GarageAPI.Models.CustomerCars;
using GarageAPI.Models;
using GarageAPI.Models.Service;
using GarageAPI.Enum;
using GarageAPI.Models.User;
using GarageAPI.Models.CustomerCars;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class ServiceHistoryController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public ServiceHistoryController(GarageAPIDbContext context)
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
        [Route("api/GetCarsServiceHistoryToList/{garageID:long}")]
        public async Task<ActionResult<IEnumerable<ServiceHistoryDTO>>> GetCarsServiceHistoryToList([FromRoute] long garageID)
        {
            string StoredProc = "exec GetCarSServiceHistoryToList @GarageID = " + garageID;
            List<ServiceHistoryDTO> carsServiceHistoryList = await dbContext.ServiceHistoryDTO.FromSqlRaw(StoredProc).ToListAsync();
            if (carsServiceHistoryList == null)
            {
                return NotFound();
            }
            return Ok(carsServiceHistoryList);
        }


        [HttpGet]
        [Route("api/GetCarServiceHistoryByCustomerCarID/{id:long}")]
        public async Task<ActionResult<IEnumerable<ServiceHistoryDTO>>> GetCarServiceHistoryByCustomerCarID([FromRoute] long id)
        {
            string StoredProc = "exec GetCarServiceHistory @CustomerCarID = " + id;
            List<ServiceHistoryDTO> carServiceHistory = await dbContext.ServiceHistoryDTO.FromSqlRaw(StoredProc).ToListAsync();
            if (carServiceHistory == null)
            {
                return NotFound();
            }
            return Ok(carServiceHistory);
        }

        [HttpGet]
        [Route("api/GetCustomerCarsServiceHistoryByValue/{searchBy}/{value}/{garageID}")]
        public async Task<ActionResult<IEnumerable<ServiceHistoryDTO>>> GetCustomerCarsServiceHistoryByValue([FromRoute] int searchBy,string value, long garageID)
        {
            CustomerCar userModelList = new CustomerCar();
            if (searchBy == 0)
            {
                userModelList = await dbContext.CustomerCars.FirstOrDefaultAsync(c => (c.VIN.Contains(value) || c.LicencePlate.Contains(value)));
            }
            else if (searchBy == 1)
            {
                userModelList = await dbContext.CustomerCars.FirstOrDefaultAsync(c => (c.VIN.Contains(value) ));
            }
            else
            {
                userModelList = await dbContext.CustomerCars.FirstOrDefaultAsync(c => (c.LicencePlate.Contains(value)));
                
            }
            var userModel = await GetCarServiceHistoryByCustomerCarID(userModelList.ID);
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
        [Route("api/AddCustomerCarserviceHistory")]
        public async Task<IActionResult> AddCustomerCarserviceHistory(AddCustomerCarServiceHistoryRequest addCustomerCarserviceHistoryRequest)
        {
            var serviceHistory = new ServiceHistory()
            {
               CustomerCar = await dbContext.CustomerCars.FindAsync(addCustomerCarserviceHistoryRequest.CustomerCarID),
               ServiceDate = addCustomerCarserviceHistoryRequest.ServiceDate,
               Description = addCustomerCarserviceHistoryRequest.Description,
               ServiceKilometer = addCustomerCarserviceHistoryRequest.ServiceKilometer,
               Engineer = await dbContext.Users.FindAsync(addCustomerCarserviceHistoryRequest.EngineerID),
               StartPrice = addCustomerCarserviceHistoryRequest.StartPrice,
               DiscountPrice = addCustomerCarserviceHistoryRequest.DiscountPrice,
               DiscountPercentage = addCustomerCarserviceHistoryRequest.DiscountPercentage,
               isDiscountPercentage = addCustomerCarserviceHistoryRequest.DiscountPercentage is null ? false : true,
               FinalPrice = addCustomerCarserviceHistoryRequest.FinalPrice,
               StartingDate = addCustomerCarserviceHistoryRequest.StartingDate,
               FinishingDate = addCustomerCarserviceHistoryRequest.FinishingDate,
               GarageID = addCustomerCarserviceHistoryRequest.GarageID
            };
            await dbContext.ServiceHistory.AddAsync(serviceHistory);
            await dbContext.SaveChangesAsync();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ServiceHistory serviceHistoryGet = await dbContext.ServiceHistory.FirstOrDefaultAsync(x => x.CustomerCar == serviceHistory.CustomerCar &&
                x.GarageID == serviceHistory.GarageID &&
                x.ServiceDate == serviceHistory.ServiceDate &&
                x.Engineer == serviceHistory.Engineer &&
                x.ServiceKilometer == serviceHistory.ServiceKilometer);
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            List<int> serviceHistoryItemsList = addCustomerCarserviceHistoryRequest.ServiceItemsList.Where(x => int.TryParse(x, out _))
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
            //List<ServiceHistory> serviceHistory = await dbContext.ServiceHistory.Where(x=> x.CustomerCar == id).ToListAsync();
            //if (serviceHistory != null)
            //{
            //    for(int i = 0; i < serviceHistory.Count; i++)
            //    {
            //        dbContext.Remove(serviceHistory[i]);
            //        await dbContext.SaveChangesAsync();
            //    }
            //    return Ok(serviceHistory);
            //}
            return NotFound();
        }
    }
}