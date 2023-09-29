using GarageAPI.Data;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class ServiceItemsController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public ServiceItemsController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        [Route("api/GetServiceItems")]
        public async Task<IActionResult> GetServiceItems()
        {
            return Ok(await dbContext.ServiceItems.ToListAsync());
        }

        [HttpGet]
        [Route("api/GetServiceItemsToList")]
        public Task<IActionResult> GetServiceItemsToList()
        {
            List<ServiceItems> serviceItems = dbContext.ServiceItems.ToList();
            return Task.FromResult<IActionResult>(Ok(serviceItems));
        }

        [HttpGet]
        [Route("api/GetServiceItemsByID/{id:long}")]
        public async Task<IActionResult> GetServiceItemsByID([FromRoute] long id)
        {
            var serviceItem = await dbContext.ServiceItems.FindAsync(id);
            if (serviceItem == null)
            {
                return NotFound();
            }
            return Ok(serviceItem);
        }

        [HttpPost]
        [Route("api/AddServiceItem")]
        public async Task<IActionResult> AddServiceItem(AddServiceItemRequest addServiceItemRequest)
        {
            var serviceItem = new ServiceItems()
            {
                Description = addServiceItemRequest.Description,
                Price = addServiceItemRequest.Price,
                GarageID = addServiceItemRequest.GarageID
            };
            await dbContext.ServiceItems.AddAsync(serviceItem);
            await dbContext.SaveChangesAsync();

            return Ok(serviceItem);
        }

        [HttpPut]
        [Route("api/UpdateServiceItemByID/{id:long}")]
        public async Task<IActionResult> UpdateServiceItemByID([FromRoute] long id, UpdateServiceItemRequest updateServiceItemRequest)
        {
            var serviceItem = await dbContext.ServiceItems.FindAsync(id);
            if (serviceItem != null)
            {
                serviceItem.Description = updateServiceItemRequest.Description;
                serviceItem.Price = updateServiceItemRequest.Price;
                await dbContext.SaveChangesAsync();
                return Ok(serviceItem);
            }
            return NotFound();
        }
    }
}