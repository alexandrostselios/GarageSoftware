using GarageAPI.Data;
using GarageAPI.Models;
using GarageAPI.Models.CarEngineTypes;
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

        [HttpPut]
        [Route("api/UpdateGarageDetails/{garageID:long}")]
        public async Task<IActionResult> UpdateGarageDetails([FromRoute] long garageID, [FromBody] UpdateGarageDetailsTypeRequest updateGarageDetailsTypeRequest)
        {
            var garageDetails = await dbContext.GarageDetails.FirstOrDefaultAsync(x => x.ID == garageID);
            if (garageDetails != null)
            {
                garageDetails.Description = updateGarageDetailsTypeRequest.Description;
                garageDetails.isActive = updateGarageDetailsTypeRequest.isActive;
                garageDetails.Domain = updateGarageDetailsTypeRequest.Domain;
                garageDetails.LegalName = updateGarageDetailsTypeRequest.LegalName;
                garageDetails.VATNumber = updateGarageDetailsTypeRequest.VATNumber;
                garageDetails.VATOffice = updateGarageDetailsTypeRequest.VATOffice;
                garageDetails.Country = updateGarageDetailsTypeRequest.Country;
                garageDetails.Region = updateGarageDetailsTypeRequest.Region;
                garageDetails.City = updateGarageDetailsTypeRequest.City;
                garageDetails.Address = updateGarageDetailsTypeRequest.Address;
                garageDetails.ZipCode = updateGarageDetailsTypeRequest.ZipCode;
                garageDetails.PhoneNumber = updateGarageDetailsTypeRequest.PhoneNumber;
                garageDetails.Email = updateGarageDetailsTypeRequest.Email;
                garageDetails.Website = updateGarageDetailsTypeRequest.Website;
                garageDetails.ModifyDate = updateGarageDetailsTypeRequest.ModifyDate;

                await dbContext.SaveChangesAsync();
                return Ok(garageDetails);
            }
            return NotFound();
        }
    }
}