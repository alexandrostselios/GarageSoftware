using GarageAPI.Data;
using GarageAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public NotificationController(GarageAPIDbContext context)
        {
            dbContext = context;
        }


        [HttpPost]
        [Route("api/AddNotificationEmail")]
        public async Task<IActionResult> AddNotificationEmail(Email email)
        {
            await dbContext.Email.AddAsync(email);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}