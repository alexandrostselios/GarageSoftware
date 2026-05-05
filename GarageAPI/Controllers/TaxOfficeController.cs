using GarageAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    public class TaxOfficeController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public TaxOfficeController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/GetTaxOffices")]
        public async Task<IActionResult> GetTaxOffices()
        {
            return Ok(await dbContext.TaxOffices.ToListAsync());
        }

        [HttpGet]
        [Route("api/GetTaxOfficeByID/{id:long}")]
        public async Task<IActionResult> GetTaxOfficeByID([FromRoute] long id)
        {
            var taxOffice = await dbContext.TaxOffices.FindAsync(id);
            if (taxOffice == null)
            {
                return NotFound();
            }
            return Ok(taxOffice);
        }
    }
}
