using GarageAPI.Data;
using GarageAPI.Enum;
using GarageAPI.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Models.User.Employee;
using GarageAPI.ViewModels;
using GarageAPI.Models.User.Employees;
using GarageAPI.Models.User.Customers;
using GarageAPI.Models.User.Engineers;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {

        private readonly GarageAPIDbContext dbContext;
        private readonly IEmailSender _emailSender;

        public EmployeeController(GarageAPIDbContext context, IEmailSender emailSender)
        {
            dbContext = context;
            this._emailSender = emailSender;
        }

        [HttpGet]
        [Route("api/GetEmployeesToList/{garageID:long}")]
        public async Task<IActionResult> GetEmployeesToList(long garageID)
        {
            var query = from employee in dbContext.Employee
                        join user in dbContext.Users
                        on employee.UserID equals user.ID
                        where employee.GarageID == garageID
                        select new EmployeeViewModel
                        {
                            EmployeeID = employee.EmployeeID,
                            EmployeeSurname = employee.EmployeeSurname,
                            EmployeeName = employee.EmployeeName,
                            EmployeeEmail = employee.EmployeeEmail,
                            CreationDate = employee.CreationDate,
                            ModifiedDate = employee.ModifiedDate,
                            GarageID = employee.GarageID,
                            UserID = employee.UserID,
                            EmployeeHomePhone = employee.EmployeeHomePhone,
                            EmployeeMobilePhone = employee.EmployeeMobilePhone,
                            EmployeeComment = employee.EmployeeComment,
                            // Additional properties from Users table
                            EnableAccess = (long) user.EnableAccess,
                            LastLoginDate = user.LastLoginDate,
                            EmployeePhoto = employee.EmployeePhoto
                        };

            var employeeViewModel = await query.ToListAsync();

            if (employeeViewModel.Any())
            {
                return Ok(employeeViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/GetEmployeeByID/{EmployeeID:long}/{garageID:long}")]
        public async Task<IActionResult> GetEmployeeByID([FromRoute] long EmployeeID, long garageID)
        {
            var query = from employee in dbContext.Employee
                        join user in dbContext.Users
                        on employee.UserID equals user.ID
                        where employee.EmployeeID == EmployeeID && employee.GarageID == garageID
                        select new EmployeeViewModel
                        {
                            EmployeeID = employee.EmployeeID,
                            EmployeeSurname = employee.EmployeeSurname,
                            EmployeeName = employee.EmployeeName,
                            EmployeeEmail = employee.EmployeeEmail,
                            CreationDate = employee.CreationDate,
                            ModifiedDate = employee.ModifiedDate,
                            GarageID = employee.GarageID,
                            UserID = employee.UserID,
                            EmployeeHomePhone = employee.EmployeeHomePhone,
                            EmployeeMobilePhone = employee.EmployeeMobilePhone,
                            EmployeeComment = employee.EmployeeComment,
                            // Populate additional properties from Users table
                            EnableAccess = (long) user.EnableAccess,
                            LastLoginDate = user.LastLoginDate,
                            EmployeePhoto = employee.EmployeePhoto
                        };

            var employeeViewModel = await query.FirstOrDefaultAsync();

            if (employeeViewModel != null)
            {
                return Ok(employeeViewModel);
            }
            else
            {
                return NotFound();
            }
            //return Ok(await dbContext.Employee.FirstOrDefaultAsync(e => e.EmployeeID == EmployeeID && e.GarageID == garageID));
        }


        //[HttpGet]
        //[Route("api/GetEmployeeByIDToList/{EmployeeID:long}/{garageID:long}")]
        //public async Task<IActionResult> GetEmployeeByIDToList([FromRoute] long EmployeeID, long garageID)
        //{
        //    var user = await dbContext.Employee.FirstOrDefaultAsync(x => x.EmployeeID == EmployeeID && x.GarageID == garageID);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(await dbContext.Employee.Where(c => (c.EmployeeID == EmployeeID && c.GarageID == garageID)).ToListAsync());
        //}

        //[HttpGet]
        //[Route("api/CheckEmployeeExist/{EmployeeID:long}/{garageID:long}")]
        //public async Task<IActionResult> CheckEmployeeExist([FromRoute] long EmployeeID, long garageID)
        //{
        //    return Ok(dbContext.Employee.Any(e => e.EmployeeID == EmployeeID && e.GarageID == garageID));
        //}

        //[HttpPost]
        //[Route("api/AddEmployee")]
        //public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        //{
        //    var user = new Users()
        //    {
        //        Email = addEmployeeRequest.EmployeeEmail,
        //        Password = addEmployeeRequest.EmployeePassword,
        //        CreationDate = addEmployeeRequest.CreationDate,
        //        UserType = Enum.UserType.Employee,
        //        EnableAccess = addEmployeeRequest.EnableAccess
        //        // Add other user properties as needed
        //    };
        //    await dbContext.Users.AddAsync(user);
        //    await dbContext.SaveChangesAsync();

        //    var Employee = new Employee()
        //    {
        //        EmployeeSurname = addEmployeeRequest.EmployeeSurname,
        //        EmployeeName = addEmployeeRequest.EmployeeName,
        //        EmployeeEmail = addEmployeeRequest.EmployeeEmail,
        //        GarageID = addEmployeeRequest.GarageID,
        //        CreationDate = addEmployeeRequest.CreationDate,
        //        EmployeePhoto = addEmployeeRequest.EmployeePhoto,
        //        EmployeeComment = addEmployeeRequest.EmployeeComment,
        //        EmployeeHomePhone = addEmployeeRequest.EmployeeHomePhone,
        //        EmployeeMobilePhone = addEmployeeRequest.EmployeeMobilePhone,
        //        UserID = user.ID
        //    };
        //    await dbContext.Employee.AddAsync(Employee);
        //    await dbContext.SaveChangesAsync();

        //    return Ok(Employee);
        //}

        //[HttpPost]
        //[Route("api/AddEmployeeByList")]
        //public async Task<IActionResult> AddEmployeeByList(List<AddEmployeeRequest> addEmployeeRequest)
        //{
        //    for(int i = 0; i <= addEmployeeRequest.Count; i++)
        //    {
        //        var user = new Users()
        //        {
        //            Email = addEmployeeRequest[i].EmployeeEmail,
        //            Password = addEmployeeRequest[i].EmployeePassword,
        //            CreationDate = addEmployeeRequest[i].CreationDate,
        //            UserType = Enum.UserType.Employee,
        //            EnableAccess = addEmployeeRequest[i].EnableAccess
        //            // Add other user properties as needed
        //        };
        //        await dbContext.Users.AddAsync(user);
        //        await dbContext.SaveChangesAsync();

        //        var Employee = new Employee()
        //        {
        //            EmployeeSurname = addEmployeeRequest[i].EmployeeSurname,
        //            EmployeeName = addEmployeeRequest[i].EmployeeName,
        //            EmployeeEmail = addEmployeeRequest[i].EmployeeEmail,
        //            GarageID = addEmployeeRequest[i].GarageID,
        //            CreationDate = addEmployeeRequest[i].CreationDate,
        //            EmployeePhoto = addEmployeeRequest[i].EmployeePhoto,
        //            EmployeeComment = addEmployeeRequest[i].EmployeeComment,
        //            EmployeeHomePhone = addEmployeeRequest[i].EmployeeHomePhone,
        //            EmployeeMobilePhone = addEmployeeRequest[i].EmployeeMobilePhone,
        //            UserID = user.ID
        //        };
        //        await dbContext.Employee.AddAsync(Employee);
        //        await dbContext.SaveChangesAsync();
        //    }

        //    return Ok();
        //}

        [HttpPut]
        [Route("api/UpdateEmployee/{employeeID:long}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] long employeeID, UpdateEmployeeRequest updateEmployeeRequest)
        {
            // Find the Employee entity by ID
            var employee = await dbContext.Employee.FindAsync(employeeID);

            if (employee != null)
            {
                // Update properties of the Employee entity
                if (!(updateEmployeeRequest.EmployeeName is null)) employee.EmployeeName = updateEmployeeRequest.EmployeeName;
                if (!(updateEmployeeRequest.EmployeeSurname is null)) employee.EmployeeSurname = updateEmployeeRequest.EmployeeSurname;
                if (!(updateEmployeeRequest.EmployeeEmail is null)) employee.EmployeeEmail = updateEmployeeRequest.EmployeeEmail;
                if (!(updateEmployeeRequest.ModifiedDate is null)) employee.ModifiedDate = updateEmployeeRequest.ModifiedDate;
                if (!(updateEmployeeRequest.EmployeePhoto is null)) employee.EmployeePhoto = updateEmployeeRequest.EmployeePhoto;
                if (!(updateEmployeeRequest.EmployeeHomePhone is null)) employee.EmployeeHomePhone = updateEmployeeRequest.EmployeeHomePhone;
                if (!(updateEmployeeRequest.EmployeeMobilePhone is null)) employee.EmployeeMobilePhone = updateEmployeeRequest.EmployeeMobilePhone;
                if (!(updateEmployeeRequest.EmployeeComment is null)) employee.EmployeeComment = updateEmployeeRequest.EmployeeComment;

                // Find the user entity associated with the Employee
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.ID == employee.UserID);

                if (user != null)
                {
                    // Update properties of the user entity
                    if (updateEmployeeRequest.EnableAccess != null) user.EnableAccess = (EnableAccess)updateEmployeeRequest.EnableAccess;
                    if (updateEmployeeRequest.LastLoginDate != null) user.LastLoginDate = updateEmployeeRequest.LastLoginDate;
                    if (updateEmployeeRequest.ModifiedDate != null) user.ModifiedDate = updateEmployeeRequest.ModifiedDate;
                    if (updateEmployeeRequest.EmployeeEmail != null) user.Email = updateEmployeeRequest.EmployeeEmail;

                    // Save changes to both entities
                    await dbContext.SaveChangesAsync();

                    return Ok(new { Employee = employee, User = user }); // Return updated entities
                }
                else
                {
                    return NotFound("User not found");
                }
            }
            else
            {
                return NotFound("Employee not found");
            }
        }

        [HttpPost]
        [Route("api/AddEmployee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            var user = new Users()
            {
                Email = addEmployeeRequest.EmployeeEmail,
                Password = addEmployeeRequest.EmployeePassword,
                CreationDate = addEmployeeRequest.CreationDate,
                UserType = Enum.UserType.Employee,
                EnableAccess = addEmployeeRequest.EnableAccess
                // Add other user properties as needed
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var employee = new Employee()
            {
                EmployeeSurname = addEmployeeRequest.EmployeeSurname,
                EmployeeName = addEmployeeRequest.EmployeeName,
                EmployeeEmail = addEmployeeRequest.EmployeeEmail,
                GarageID = addEmployeeRequest.GarageID,
                CreationDate = addEmployeeRequest.CreationDate,
                EmployeePhoto = addEmployeeRequest.EmployeePhoto,
                EmployeeComment = addEmployeeRequest.EmployeeComment,
                EmployeeHomePhone = addEmployeeRequest.EmployeeHomePhone,
                EmployeeMobilePhone = addEmployeeRequest.EmployeeMobilePhone,
                UserID = user.ID
            };
            await dbContext.Employee.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut]
        [Route("api/UpdateEmployeeLogin/{employeeID:long}")]
        public async Task<IActionResult> UpdateEmployeeLogin([FromRoute] long employeeID, UpdateEmployeeLogin updateEmployeeLogin)
        {

            // Find the user entity associated with the customer
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.ID == employeeID);

            if (user != null)
            {
                // Find the customer entity by ID
                var employee = await dbContext.Employee.FirstOrDefaultAsync(x => x.UserID == user.ID);

                if (employee != null)
                {
                    if (updateEmployeeLogin.LastLoginDate != null) user.LastLoginDate = updateEmployeeLogin.LastLoginDate;
                    // Save changes to both entities
                    await dbContext.SaveChangesAsync();
                    return Ok(new { Employee = employee, User = user }); // Return updated entities
                }
                else
                {
                    return NotFound("Employee not found");
                }
            }
            else
            {
                return NotFound("Employee not found");
            }
        }
    }
}