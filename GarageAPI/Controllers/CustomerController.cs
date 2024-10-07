using GarageAPI.Data;
using GarageAPI.Enum;
using GarageAPI.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Models.User.Customer;
using GarageAPI.ViewModels;
//using GarageAPI.Models.Customers;
using GarageAPI.Models.User.Customers;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class CustomerController : Controller
    {

        private readonly GarageAPIDbContext dbContext;
        private readonly IEmailSender _emailSender;

        public CustomerController(GarageAPIDbContext context, IEmailSender emailSender)
        {
            dbContext = context;
            this._emailSender = emailSender;
        }

        //[HttpGet]
        //[Route("api/GetCustomersToList/{garageID:long}")]
        //public async Task<IActionResult> GetCustomersToList(long garageID)
        //{
        //    return Ok(await dbContext.Customer.Where(c => c.GarageID == garageID).ToListAsync());
        //}

        [HttpGet]
        [Route("api/GetCustomersToList/{garageID:long}")]
        public async Task<IActionResult> GetCustomersToList(long garageID)
        {
            var query = from customer in dbContext.Customer
                        join user in dbContext.Users
                        on customer.UserID equals user.ID
                        where customer.GarageID == garageID
                        select new CustomerViewModel
                        {
                            CustomerID = customer.CustomerID,
                            CustomerSurname = customer.CustomerSurname,
                            CustomerName = customer.CustomerName,
                            CustomerEmail = customer.CustomerEmail,
                            CreationDate = customer.CreationDate,
                            ModifiedDate = customer.ModifiedDate,
                            GarageID = customer.GarageID,
                            UserID = customer.UserID,
                            CustomerHomePhone = customer.CustomerHomePhone,
                            CustomerMobilePhone = customer.CustomerMobilePhone,
                            CustomerComment = customer.CustomerComment,
                            // Additional properties from Users table
                            EnableAccess = (long) user.EnableAccess,
                            LastLoginDate = user.LastLoginDate,
                            CustomerPhoto = customer.CustomerPhoto
                        };

            var customerViewModels = await query.ToListAsync();

            if (customerViewModels.Any())
            {
                return Ok(customerViewModels);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/GetCustomerByID/{customerID:long}/{garageID:long}")]
        public async Task<IActionResult> GetCustomerByID([FromRoute] long customerID, long garageID)
        {
            var query = from customer in dbContext.Customer
                        join user in dbContext.Users
                        on customer.UserID equals user.ID
                        where customer.CustomerID == customerID && customer.GarageID == garageID
                        select new CustomerViewModel
                        {
                            CustomerID = customer.CustomerID,
                            CustomerSurname = customer.CustomerSurname,
                            CustomerName = customer.CustomerName,
                            CustomerEmail = customer.CustomerEmail,
                            CreationDate = customer.CreationDate,
                            ModifiedDate = customer.ModifiedDate,
                            GarageID = customer.GarageID,
                            UserID = customer.UserID,
                            CustomerHomePhone = customer.CustomerHomePhone,
                            CustomerMobilePhone = customer.CustomerMobilePhone,
                            CustomerComment = customer.CustomerComment,
                            // Populate additional properties from Users table
                            EnableAccess = (long) user.EnableAccess,
                            LastLoginDate = user.LastLoginDate,
                            CustomerPhoto = customer.CustomerPhoto
                        };

            var customerViewModel = await query.FirstOrDefaultAsync();

            if (customerViewModel != null)
            {
                return Ok(customerViewModel);
            }
            else
            {
                return NotFound();
            }
            //return Ok(await dbContext.Customer.FirstOrDefaultAsync(e => e.CustomerID == customerID && e.GarageID == garageID));
        }


        [HttpGet]
        [Route("api/GetCustomerByIDToList/{customerID:long}/{garageID:long}")]
        public async Task<IActionResult> GetCustomerByIDToList([FromRoute] long customerID, long garageID)
        {
            var user = await dbContext.Customer.FirstOrDefaultAsync(x => x.CustomerID == customerID && x.GarageID == garageID);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(await dbContext.Customer.Where(c => (c.CustomerID == customerID && c.GarageID == garageID)).ToListAsync());
        }

        [HttpGet]
        [Route("api/CheckCustomerExist/{customerID:long}/{garageID:long}")]
        public async Task<IActionResult> CheckCustomerExist([FromRoute] long customerID, long garageID)
        {
            return Ok(dbContext.Customer.Any(e => e.CustomerID == customerID && e.GarageID == garageID));
        }

        [HttpPost]
        [Route("api/AddCustomer")]
        public async Task<IActionResult> AddCustomer(AddCustomerRequest addCustomerRequest)
        {
            var user = new Users()
            {
                Email = addCustomerRequest.CustomerEmail,
                Password = addCustomerRequest.CustomerPassword,
                CreationDate = addCustomerRequest.CreationDate,
                UserType = Enum.UserType.Customer,
                EnableAccess = addCustomerRequest.EnableAccess
                // Add other user properties as needed
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var customer = new Customer()
            {
                CustomerSurname = addCustomerRequest.CustomerSurname,
                CustomerName = addCustomerRequest.CustomerName,
                CustomerEmail = addCustomerRequest.CustomerEmail,
                GarageID = addCustomerRequest.GarageID,
                CreationDate = addCustomerRequest.CreationDate,
                CustomerPhoto = addCustomerRequest.CustomerPhoto,
                CustomerComment = addCustomerRequest.CustomerComment,
                CustomerHomePhone = addCustomerRequest.CustomerHomePhone,
                CustomerMobilePhone = addCustomerRequest.CustomerMobilePhone,
                UserID = user.ID
            };
            await dbContext.Customer.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            return Ok(customer);
        }

        [HttpPost]
        [Route("api/AddCustomerByList")]
        public async Task<IActionResult> AddCustomerByList(List<AddCustomerRequest> addCustomerRequest)
        {
            for(int i = 0; i <= addCustomerRequest.Count; i++)
            {
                var user = new Users()
                {
                    Email = addCustomerRequest[i].CustomerEmail,
                    Password = addCustomerRequest[i].CustomerPassword,
                    CreationDate = addCustomerRequest[i].CreationDate,
                    UserType = Enum.UserType.Customer,
                    EnableAccess = addCustomerRequest[i].EnableAccess
                    // Add other user properties as needed
                };
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();

                var customer = new Customer()
                {
                    CustomerSurname = addCustomerRequest[i].CustomerSurname,
                    CustomerName = addCustomerRequest[i].CustomerName,
                    CustomerEmail = addCustomerRequest[i].CustomerEmail,
                    GarageID = addCustomerRequest[i].GarageID,
                    CreationDate = addCustomerRequest[i].CreationDate,
                    CustomerPhoto = addCustomerRequest[i].CustomerPhoto,
                    CustomerComment = addCustomerRequest[i].CustomerComment,
                    CustomerHomePhone = addCustomerRequest[i].CustomerHomePhone,
                    CustomerMobilePhone = addCustomerRequest[i].CustomerMobilePhone,
                    UserID = user.ID
                };
                await dbContext.Customer.AddAsync(customer);
                await dbContext.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/UpdateCustomer/{customerID:long}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] long customerID, UpdateCustomerRequest updateCustomerRequest)
        {
            // Find the customer entity by ID
            var customer = await dbContext.Customer.FindAsync(customerID);

            if (customer != null)
            {
                // Update properties of the customer entity
                if (!(updateCustomerRequest.CustomerName is null)) customer.CustomerName = updateCustomerRequest.CustomerName;
                if (!(updateCustomerRequest.CustomerSurname is null)) customer.CustomerSurname = updateCustomerRequest.CustomerSurname;
                if (!(updateCustomerRequest.CustomerEmail is null)) customer.CustomerEmail = updateCustomerRequest.CustomerEmail;
                if (!(updateCustomerRequest.ModifiedDate is null)) customer.ModifiedDate = updateCustomerRequest.ModifiedDate;
                if (!(updateCustomerRequest.CustomerPhoto is null)) customer.CustomerPhoto = updateCustomerRequest.CustomerPhoto;
                if (!(updateCustomerRequest.CustomerHomePhone is null)) customer.CustomerHomePhone = updateCustomerRequest.CustomerHomePhone;
                if (!(updateCustomerRequest.CustomerMobilePhone is null)) customer.CustomerMobilePhone = updateCustomerRequest.CustomerMobilePhone;

                // Find the user entity associated with the customer
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.ID == customer.UserID);

                if (user != null)
                {
                    // Update properties of the user entity
                    if (updateCustomerRequest.EnableAccess != null)  user.EnableAccess = (EnableAccess)updateCustomerRequest.EnableAccess;
                    if (updateCustomerRequest.LastLoginDate != null) user.LastLoginDate = updateCustomerRequest.LastLoginDate;
                    if (updateCustomerRequest.ModifiedDate != null) user.ModifiedDate = updateCustomerRequest.ModifiedDate;
                    if (updateCustomerRequest.CustomerEmail != null) user.Email = updateCustomerRequest.CustomerEmail;

                    // Save changes to both entities
                    await dbContext.SaveChangesAsync();

                    return Ok(new { Customer = customer, User = user }); // Return updated entities
                }
                else
                {
                    return NotFound("User not found");
                }
            }
            else
            {
                return NotFound("Customer not found");
            }
        }
    }
}