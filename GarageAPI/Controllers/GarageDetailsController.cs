using GarageAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    public class GarageDetailsController : Controller
    {
        private GarageAPIDbContext dbContext;

        public GarageDetailsController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/GetGarageDetails")]
        public async Task<IActionResult> GetGarageDetails()
        {
            return Ok(await dbContext.GarageDetails.ToListAsync());
        }
    }
}
