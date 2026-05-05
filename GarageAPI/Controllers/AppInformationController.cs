using GarageAPI.Data;
using GarageAPI.Models;
using GarageAPI.Models.AppInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    public class AppInformationController : Controller
    {
        private GarageAPIDbContext dbContext;

        public AppInformationController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/GetAppInformation/{garageID:long}")]
        public async Task<IActionResult> GetAppInformation(long garageID)
        {
            return Ok(await dbContext.AppInformation.Where(x => x.GarageID == garageID).ToListAsync());
        }

        [HttpPut]
        [Route("api/UpdateAppInformation/{garageID:long}")]
        public async Task<IActionResult> UpdateAppInformation([FromRoute] long garageID, [FromBody] UpdateAppInformationRequest updateAppInformationRequest)
        {
            var appInformation = await dbContext.AppInformation.FirstOrDefaultAsync(x => x.ID == garageID);
            if (appInformation != null)
            {
                appInformation.PublishDate = updateAppInformationRequest.PublishDate;
                appInformation.MajorIncrementalNumber = appInformation.MajorIncrementalNumber + 1;
                appInformation.MinorIncrementalNumber = appInformation.MinorIncrementalNumber + 1;


                await dbContext.SaveChangesAsync();
                return Ok(appInformation);
            }
            return NotFound();
        }
    }
}