using GarageAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class ReportController : Controller
    {

        private readonly GarageAPIDbContext dbContext;

        public ReportController(GarageAPIDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("api/GetDefinition")]
        public async Task<IActionResult> GetDefinition()
        {
            return Ok(await dbContext.Report.Where(x=> x.ID == 1).ToListAsync());
        }
    }
}
