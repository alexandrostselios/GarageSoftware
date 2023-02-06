using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using GarageAPI.Models;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class ServiceHistoriesController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public ServiceHistoriesController(GarageAPIDbContext context)
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
        [Route("api/GetCarServiceHistoryByUserModelsID/{id:long}")]
        public async Task<IActionResult> GetUserModelByUserID([FromRoute] long id)
        {
            string StoredProc = "exec GetCarServiceHistory @UserModelsID = " + id;
            List<ServiceHistoryDTO> carServiceHistory = await dbContext.ServiceHistoryDTO.FromSqlRaw(StoredProc).ToListAsync();

            var i = 10;//List<OutputsController> outt = new OutputsController(dbContext).Getoutput();

            if (carServiceHistory == null)
            {
                return NotFound();
            }
            return Ok(carServiceHistory);
        }
    }
}
