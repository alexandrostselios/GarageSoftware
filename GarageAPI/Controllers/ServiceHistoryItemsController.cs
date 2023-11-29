using GarageAPI.Data;
using GarageAPI.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class ServiceHistoryItemsController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public ServiceHistoryItemsController(GarageAPIDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("api/GetServiceHistoryItems")]
        public async Task<IActionResult> GetServiceHistoryItems()
        {
            return Ok(await dbContext.ServiceHistoryItems.ToListAsync());
        }

        [HttpGet]
        [Route("api/GetServiceHistoryItemsByServiceHistoryID/{id:long}/{garageID:long}")]
        public async Task<IActionResult> GetServiceHistoryItemsByServiceHistoryID(long id, long garageID)
        {
            List<ServiceHistoryItems> serviceHistoryItems = await dbContext.ServiceHistoryItems.Where(x => x.SHID == id && x.GarageID == garageID).ToListAsync();
            List<ServiceHistoryItemsDTO> serviceHistoryItemsDTO =   new List<ServiceHistoryItemsDTO>();
            for(int i=0; i<serviceHistoryItems.Count; i++)
            {
                serviceHistoryItemsDTO.Add(new ServiceHistoryItemsDTO()
                {
                    ID = serviceHistoryItems[i].ID,
                    SHID = serviceHistoryItems[i].SHID,
                    SIID = serviceHistoryItems[i].SIID,
                    GarageID = serviceHistoryItems[i].GarageID
                });
            }
            var result = dbContext.ServiceHistoryItems.Where(x => x.SHID == id && x.GarageID == garageID).Join(dbContext.ServiceItems, left => left.SIID, right => right.ID, (left, right) => new
            {
                ServiceItems = right
            }); 

            return Ok(result);
        }
    }
}