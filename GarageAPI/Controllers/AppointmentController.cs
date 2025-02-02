using GarageAPI.Data;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.Service;
using GarageAPI.Models.ServiceAppointment;
using GarageAPI.Models.User.Engineers;
using GarageAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class ServiceAppointmentController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public ServiceAppointmentController(GarageAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/GetServiceAppointmentsToList")]
        public async Task<IActionResult> GetServiceAppointmentsToList()
        {
            return Ok(await dbContext.ServiceAppointment.ToListAsync());
        }

        [HttpGet]
        [Route("api/GetServiceAppointmentsToListLiteral/{garageID:long}/{customerID:long}")]
        public async Task<IActionResult> GetServiceAppointmentsToListLiteral(long garageID, long customerID)
        {
            IQueryable<ServiceAppointmentViewModel> query;
            if (customerID == 0)
            {
                 query = from serviceAppointment in dbContext.ServiceAppointment
                            join customerCar in dbContext.CustomerCars
                            on serviceAppointment.CustomerCarID equals customerCar.ID
                            join customer in dbContext.Customer
                            on customerCar.Customer.CustomerID equals customer.CustomerID
                            join carModelManufacturerYear in dbContext.CarModelManufacturerYear
                            on customerCar.ModelManufacturerYear.ID equals carModelManufacturerYear.ID
                            join carManufacturer in dbContext.CarManufacturer
                            on carModelManufacturerYear.CarManufacturerID equals carManufacturer.ID
                            join carModel in dbContext.CarModels
                            on carModelManufacturerYear.CarModelID equals carModel.ID
                            where serviceAppointment.GarageID == garageID
                            select new ServiceAppointmentViewModel
                            {
                                ID = serviceAppointment.ID,
                                ServiceAppointmentDate = serviceAppointment.ServiceAppointmentDate,
                                ServiceAppointmentComments = serviceAppointment.ServiceAppointmentComments,
                                ServiceAppointmentStatus = serviceAppointment.ServiceAppointmentStatus,
                                CustomerID = customer.CustomerID,
                                CustomerCarID = customerCar.ID,
                                Customer = customer.CustomerSurname + ' ' + customer.CustomerName,
                                ManufacturerName = carManufacturer.ManufacturerName,
                                ModelName = carModel.ModelName,
                                LicencePlate = customerCar.LicencePlate,
                                VIN = customerCar.VIN,
                                Color = (Enum.Colors)customerCar.Color,
                                Kilometer = serviceAppointment.Kilometer,
                                GarageID = customerCar.GarageID
                            };
            }
            else
            {
                query = from serviceAppointment in dbContext.ServiceAppointment
                            join customerCar in dbContext.CustomerCars
                            on serviceAppointment.CustomerCarID equals customerCar.ID
                            join customer in dbContext.Customer
                            on customerCar.Customer.CustomerID equals customer.CustomerID
                            join carModelManufacturerYear in dbContext.CarModelManufacturerYear
                            on customerCar.ModelManufacturerYear.ID equals carModelManufacturerYear.ID
                            join carManufacturer in dbContext.CarManufacturer
                            on carModelManufacturerYear.CarManufacturerID equals carManufacturer.ID
                            join carModel in dbContext.CarModels
                            on carModelManufacturerYear.CarModelID equals carModel.ID
                            where serviceAppointment.GarageID == garageID
                            && serviceAppointment.CustomerID == customerID
                            select new ServiceAppointmentViewModel
                            {
                                ID = serviceAppointment.ID,
                                ServiceAppointmentDate = serviceAppointment.ServiceAppointmentDate,
                                ServiceAppointmentComments = serviceAppointment.ServiceAppointmentComments,
                                ServiceAppointmentStatus = serviceAppointment.ServiceAppointmentStatus,
                                CustomerID = customer.CustomerID,
                                CustomerCarID = customerCar.ID,
                                Customer = customer.CustomerSurname + ' ' + customer.CustomerName,
                                ManufacturerName = carManufacturer.ManufacturerName,
                                ModelName = carModel.ModelName,
                                LicencePlate = customerCar.LicencePlate,
                                VIN = customerCar.VIN,
                                Color = (Enum.Colors)customerCar.Color,
                                Kilometer = serviceAppointment.Kilometer,
                                GarageID = customerCar.GarageID
                            };
            }
            

            var serviceAppointmentViewModels = await query.ToListAsync();

            if (serviceAppointmentViewModels.Any())
            {
                return Ok(serviceAppointmentViewModels);
            }
            else
            {
                return NotFound();
            }
            //string StoredProc = "exec GetServiceAppointmentsToListLiteral @GarageID = " + garageID;
            //List<ServiceAppointmentViewModel> serviceAppointments = await dbContext.ServiceAppointmentViewModel.FromSqlRaw(StoredProc).ToListAsync();
            //if (serviceAppointments == null)
            //{
            //    return NotFound();
            //}
            //return Ok(serviceAppointments);
        }

        [HttpGet]
        [Route("api/GetServiceAppointmentByID/{id:long}")]
        public async Task<IActionResult> GetServiceAppointmentByID([FromRoute] long id)
        {
            var serviceAppointment = await dbContext.ServiceAppointment.FindAsync(id);
            if (serviceAppointment == null)
            {
                return NotFound();
            }
            return Ok(serviceAppointment);
        }

        [HttpGet]
        [Route("api/GetServiceAppointmentByIDLiteral/{serviceAppointmentID:long}/{garageID:long}")]
        public async Task<IActionResult> GetServiceAppointmentByIDLiteral(long serviceAppointmentID, long garageID)
        {
            var query = from serviceAppointment in dbContext.ServiceAppointment
                        join customerCar in dbContext.CustomerCars
                        on serviceAppointment.CustomerCarID equals customerCar.ID
                        join customer in dbContext.Customer
                        on customerCar.Customer.CustomerID equals customer.CustomerID
                        join carModelManufacturerYear in dbContext.CarModelManufacturerYear
                        on customerCar.ModelManufacturerYear.ID equals carModelManufacturerYear.ID
                        join carManufacturer in dbContext.CarManufacturer
                        on carModelManufacturerYear.CarManufacturerID equals carManufacturer.ID
                        join carModel in dbContext.CarModels
                        on carModelManufacturerYear.CarModelID equals carModel.ID
                        where serviceAppointment.GarageID == garageID && serviceAppointment.ID == serviceAppointmentID
                        select new ServiceAppointmentViewModel
                        {
                            ID = serviceAppointment.ID,
                            ServiceAppointmentDate = serviceAppointment.ServiceAppointmentDate,
                            ServiceAppointmentComments = serviceAppointment.ServiceAppointmentComments,
                            ServiceAppointmentStatus = serviceAppointment.ServiceAppointmentStatus,
                            CustomerID = customer.CustomerID,
                            Customer = customer.CustomerSurname + ' ' + customer.CustomerName,
                            ManufacturerName = carManufacturer.ManufacturerName,
                            ModelName = carModel.ModelName,
                            LicencePlate = customerCar.LicencePlate,
                            VIN = customerCar.VIN,
                            Color = (Enum.Colors)customerCar.Color,
                            Kilometer = serviceAppointment.Kilometer,
                            GarageID = customerCar.GarageID
                        };

            var serviceAppointmentViewModel = await query.FirstOrDefaultAsync(); // FirstOrDefaultAsync to get a single item

            if (serviceAppointmentViewModel != null)
            {
                return Ok(serviceAppointmentViewModel);
            }
            else
            {
                return NotFound();
            }
            //string StoredProc = "exec GetServiceAppointmentsToListLiteral @GarageID = " + garageID;
            //List<ServiceAppointmentViewModel> serviceAppointments = await dbContext.ServiceAppointmentViewModel.FromSqlRaw(StoredProc).ToListAsync();
            //if (serviceAppointments == null)
            //{
            //    return NotFound();
            //}
            //return Ok(serviceAppointments);
        }

        [HttpPost]
        [Route("api/AddServiceAppointment")]
        public async Task<IActionResult> AddServiceAppointment(AddServiceAppointmentRequest addServiceAppointmentRequest)
        {
            var serviceAppointment = new ServiceAppointment()
            {
                CustomerID = addServiceAppointmentRequest.CustomerID,
                CustomerCarID = addServiceAppointmentRequest.CustomerCarID,
                Kilometer = addServiceAppointmentRequest.Kilometer,
                ServiceAppointmentDate = addServiceAppointmentRequest.ServiceAppointmentDate,
                ServiceAppointmentComments = addServiceAppointmentRequest.ServiceAppointmentComments,
                ServiceAppointmentStatus = addServiceAppointmentRequest.ServiceAppointmentStatus,
                GarageID = addServiceAppointmentRequest.GarageID,
            };
            await dbContext.ServiceAppointment.AddAsync(serviceAppointment);
            await dbContext.SaveChangesAsync();

            return Ok(serviceAppointment);
        }

        [HttpPut]
        [Route("api/UpdateServiceAppointment/{serviceAppointmentID:long}")]
        public async Task<IActionResult> UpdateServiceAppointment([FromRoute] long serviceAppointmentID, UpdateServiceAppointmentRequest updateServiceAppointmentRequest)
        {
            // Find the user entity associated with the customer
            var serviceAppointment = await dbContext.ServiceAppointment.FirstOrDefaultAsync(s => s.ID == serviceAppointmentID);

            if (serviceAppointment != null)
            {
                if (updateServiceAppointmentRequest.Kilometer != null) serviceAppointment.Kilometer = updateServiceAppointmentRequest.Kilometer;
                if (updateServiceAppointmentRequest.ServiceAppointmentDate != null) serviceAppointment.ServiceAppointmentDate = updateServiceAppointmentRequest.ServiceAppointmentDate;
                if (updateServiceAppointmentRequest.ServiceAppointmentComments != null) serviceAppointment.ServiceAppointmentComments = updateServiceAppointmentRequest.ServiceAppointmentComments;
                if (updateServiceAppointmentRequest.ServiceAppointmentStatus != null) serviceAppointment.ServiceAppointmentStatus = updateServiceAppointmentRequest.ServiceAppointmentStatus;

                // Save changes to both entities
                await dbContext.SaveChangesAsync();
                return Ok(new { ServiceAppointment = serviceAppointment}); // Return updated entities
            }
            else
            {
                return NotFound("Service Appointment not found");
            }
        }
    }
}