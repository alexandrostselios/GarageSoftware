using GarageAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class SettingsController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public SettingsController(GarageAPIDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("api/GetSettings")]
        public async Task<IActionResult> GetSettings()
        {
            return Ok(await dbContext.Settings.ToListAsync());
        }

        [HttpGet]
        [Route("api/GetUserSettings")]
        public async Task<IActionResult> GetUserSettings()
        {
            return Ok(await dbContext.Settings.ToListAsync());
        }
    }
}