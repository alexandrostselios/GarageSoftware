using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using GarageAPI.Models.CustomerCars;
using GarageAPI.Models.User.Customers;
using GarageAPI.Enum;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class CustomerCarsController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public CustomerCarsController(GarageAPIDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("api/GetUserModels/{garageID:long}")]
        public async Task<IActionResult> GetUserModels(long garageID)
        {
            // Fetch customer details
            var customerDetails = await dbContext.Customer
                .Where(c => c.GarageID == garageID)
                .Select(c => new
                {
                    c.CustomerID,
                    c.CustomerName,
                    c.CustomerSurname
                })
                .ToListAsync();

            if (customerDetails == null || !customerDetails.Any())
            {
                // Handle if no customer details found
                return NotFound("No customer details found for the specified garage.");
            }

            // Fetch customer cars for the specified garage
            var customerCars = await dbContext.CustomerCars
                .Where(cc => cc.GarageID == garageID)
                .Include(cc => cc.Customer)
                .Include(cc => cc.ModelManufacturerYear.CarManufacturer)
                .Include(cc => cc.ModelManufacturerYear.CarModel)
                .Include(cc => cc.EngineType)
                .ToListAsync();

            // Group customer cars by customer
            var groupedCustomerCars = customerCars
                .GroupBy(cc => cc.Customer)
                .Select(group => new
                {
                    CustomerID = group.Key.CustomerID,
                    CustomerName = group.Key.CustomerName,
                    CustomerSurname = group.Key.CustomerSurname,
                    Cars = group.Select(cc => new
                    {
                        cc.ID,
                        ManufacturerName = cc.ModelManufacturerYear.CarManufacturer.ManufacturerName,
                        ModelName = cc.ModelManufacturerYear.CarModel.ModelName,
                        EngineType = cc.EngineType.EngineType,
                        cc.LicencePlate,
                        cc.VIN,
                        cc.Color,
                        cc.Kilometer,
                        cc.CarImage,
                        cc.GarageID
                    }).ToList()
                }).ToList();

            return Ok(groupedCustomerCars);
        }

        //return Ok(await dbContext.CustomerCars.ToListAsync());

        [HttpGet]
        [Route("api/GetCustomerCarsByCustomerID/{garageID:long}/{customerID:long}")]
        public async Task<IActionResult> GetCustomerCarsByCustomerID([FromRoute] long garageID, long customerID)
        {
            string StoredProc = "exec GetCustomerCars @CustomerID = " + customerID;
            List<CustomerCarDTO> customerCars = await dbContext.CustomerCarDTO.FromSqlRaw(StoredProc).ToListAsync();
            //List<OutputsController> outt = new OutputsController(dbContext).Getoutput();

            if (customerCars == null || customerCars.Count == 0)
            {
                return NotFound("No cars found for the specified customer ID.");
            }
            return Ok(customerCars);
        }

        [HttpGet]
        [Route("api/GetCustomerCarByCarID/{carID:long}")]
        public async Task<IActionResult> GetCustomerCarByCarID([FromRoute] long carID)
        {
            string StoredProc = "exec GetCustomerCar @CustomerCarID = " + carID;
            List<CustomerCarDTO> userModelCar = await dbContext.CustomerCarDTO.FromSqlRaw(StoredProc).ToListAsync();

            if (userModelCar == null)
            {
                return NotFound();
            }
            return Ok(userModelCar);
        }

        [HttpPost]
        [Route("api/AddCustomerCar")]
        public async Task<IActionResult> AddCustomerCar(AddCustomerCarRequest addCustomerCarRequest)
        {
            //var temp = dbContext.CarModelManufacturerYear.Where(x => x.CarManufacturer.ID == addUserModelRequest.ModelManufacturer && x.CarModel.ID == addUserModelRequest.Model && x.CarModelYear.ID == addUserModelRequest.ModelYear);
           
            var userModel = new CustomerCar()
            {
                Customer = await dbContext.Customer.FindAsync(addCustomerCarRequest.CustomerID),
                ModelManufacturerYear = dbContext.CarModelManufacturerYear.FirstOrDefault(x => x.CarManufacturer.ID == addCustomerCarRequest.ModelManufacturer 
                        && x.CarModel.ID == addCustomerCarRequest.Model
                        && x.CarModelYear.ID == addCustomerCarRequest.ModelYear),
                LicencePlate = addCustomerCarRequest.LicencePlate,
                VIN = addCustomerCarRequest.VIN,
                Color = addCustomerCarRequest.Color,
                Kilometer = addCustomerCarRequest.Kilometer,
                CarImage = addCustomerCarRequest.CarImage,
                EngineType = await dbContext.CarEngineType.FindAsync(addCustomerCarRequest.EngineTypeID)
            };
            await dbContext.CustomerCars.AddAsync(userModel);
            await dbContext.SaveChangesAsync();

            return Ok(userModel);
        }

        [HttpPut]
        [Route("api/UpdateCustomerCar/{id:long}")]
        public async Task<IActionResult> UpdateCustomerCar([FromRoute] long id, UpdateCustomerCarRequest updateUserModelRequest)
        {
            var userModel = await dbContext.CustomerCars.FindAsync(id);
            if (userModel != null)
            {
                userModel.Color = updateUserModelRequest.Color;
                userModel.CarImage = updateUserModelRequest.CarImage;
                await dbContext.SaveChangesAsync();
                return Ok(userModel);
            }
            return Ok(userModel);
        }

        [HttpDelete]
        [Route("api/DeleteUserModel/{id:long}")]
        public async Task<IActionResult> DeleteUserModel([FromRoute] long id)
        {
            var serviceHistoryHelper = await new ServiceHistoryController(this.dbContext).DeleteServiceHistoryByUserModelID(id);
            var userModel = await dbContext.CustomerCars.FindAsync(id);
            if (userModel != null)
            {
                dbContext.Remove(userModel);
                await dbContext.SaveChangesAsync();
                return Ok(userModel);
            }
            return Ok();
        }
    }
}