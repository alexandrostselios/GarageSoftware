using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using GarageAPI.Enum;
using GarageAPI.Models.User;
using GarageAPI.Models;
using Microsoft.Data.SqlClient;
using GarageAPI.Models.User.Customers;
using GarageAPI.ViewModels;
using GarageAPI.Models.EngineerSpeciality;
using GarageAPI.Models.User.Engineer;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class UsersController : Controller
    {
        private readonly GarageAPIDbContext dbContext;
        private readonly IEmailSender _emailSender;

        public UsersController(GarageAPIDbContext context,IEmailSender emailSender)
        {
            dbContext = context;
            this._emailSender = emailSender;
        }

        [HttpGet]
        [Route("api/GetUsersExist/{id:long}/{garageID:long}")]
        public async Task<IActionResult> GetUsersExist([FromRoute] long id)
        {
            return Ok(dbContext.Users.Any(e => e.ID == id));
        }

        [HttpGet]
        [Route("api/GetUserByEmailAndPassword/{email}/{password}/{garageID}")]
        public async Task<IActionResult> GetUserByEmailAndPassword([FromRoute] string email, string password, long garageID)
        {
            var loginUser = await dbContext.Users
                .Where(user => user.Email == email && user.Password == password)
                .Select(user => new
                {
                    User = user,
                    Customer = user.UserType == UserType.Customer ?
                        dbContext.Customer.FirstOrDefault(customer => customer.UserID == user.ID && customer.GarageID == garageID) :
                        null,
                    Employee = (user.UserType == UserType.Admin || user.UserType == UserType.Employee) ?
                        dbContext.Employee.FirstOrDefault(employee => employee.UserID == user.ID) :
                        null
                })
                .FirstOrDefaultAsync();

            //var user = await dbContext.Users.FirstOrDefaultAsync(c => c.Email == email && c.Password == password);
            if (loginUser == null)
            {
                return NotFound();
            }
            LoginViewModel result;

            if (loginUser.User.UserType == UserType.Customer && loginUser.Customer != null)
            {
                result = new LoginViewModel
                {
                    ID = loginUser.User.ID,
                    Email = loginUser.User.Email,
                    Password = loginUser.User.Password, // Use caution with passwords
                    Name = loginUser.Customer.CustomerName,
                    Surname = loginUser.Customer.CustomerSurname,
                    UserType = loginUser.User.UserType,
                    GarageID = loginUser.Customer.GarageID
                };
                return Ok(result);
            }
            else if ((loginUser.User.UserType == UserType.Admin || loginUser.User.UserType == UserType.Employee) && loginUser.Employee != null)
            {
                result = new LoginViewModel
                {
                    ID = loginUser.User.ID,
                    Email = loginUser.User.Email,
                    Password = loginUser.User.Password, // Use caution with passwords
                    Name = loginUser.Employee.EmployeeName, // Adjust according to your Employee model
                    Surname = loginUser.Employee.EmployeeSurname, // Adjust according to your Employee model
                    UserType = loginUser.User.UserType,
                    GarageID = loginUser.Employee.GarageID // Adjust if needed
                };
                return Ok(result);
            }
            return null;
        }

        [HttpGet]
        [Route("api/GetLogin/{email}/{password}/{garageID}")] //Add later /{garageID}
        public async Task<IActionResult> GetLogin([FromRoute] string email, string password, long garageID)
        {
            var loginUser = await dbContext.Users
                .Where(joined => joined.Email == email &&
                                    joined.Password == password)
                .FirstOrDefaultAsync();

            if (loginUser == null)
            {
                return new ContentResult() { Content = "No such user or wrong email", StatusCode = (int)ResponseCode.NoUserFound };
            }
            else
            {
                if (loginUser.Password == password)
                {
                    if (loginUser.EnableAccess == EnableAccess.Enable)
                    {
                        return new ContentResult() { Content = "Login", StatusCode = (int)ResponseCode.Success };
                    }
                    else
                    {
                        return new ContentResult() { Content = "This user has been blocked!!!", StatusCode = (int)ResponseCode.BlockedUser };
                    }
                }
                else
                {
                    return new ContentResult() { Content = "Wrong Password.", StatusCode = (int)ResponseCode.WrongPassword };
                }
            }
        }

        [HttpGet]
        [Route("api/GetUserByID/{userID:long}/{userType:long}/{garageID:long}")]
        public async Task<IActionResult> GetUserByID([FromRoute] long userID,long userType ,long garageID)
        {
            UserViewModel userViewModel;

            if (userType == 1 || userType == 4) //Admin
            {
                var query = from employee in dbContext.Employee
                            join user in dbContext.Users
                            on employee.UserID equals user.ID
                            where  employee.GarageID == garageID
                            select new UserViewModel
                            {
                                ID = employee.EmployeeID,
                                Surname = employee.EmployeeSurname,
                                Name = employee.EmployeeName,
                                Email = employee.EmployeeEmail,
                                CreationDate = employee.CreationDate,
                                ModifiedDate = employee.ModifiedDate,
                                GarageID = employee.GarageID,
                                UserID = employee.UserID,
                                HomePhone = employee.EmployeeHomePhone,
                                MobilePhone = employee.EmployeeMobilePhone,
                                Comment = employee.EmployeeComment,
                                // Populate additional properties from Users table
                                EnableAccess = (long)user.EnableAccess,
                                LastLoginDate = user.LastLoginDate,
                                Photo = employee.EmployeePhoto
                            };

                userViewModel = await query.FirstOrDefaultAsync();
            }
            else if (userType == 2) //User
            {
                var query = from customer in dbContext.Customer
                            join user in dbContext.Users
                            on customer.UserID equals user.ID
                            where customer.CustomerID == userID && customer.GarageID == garageID
                            select new UserViewModel
                            {
                                ID = customer.CustomerID,
                                Surname = customer.CustomerSurname,
                                Name = customer.CustomerName,
                                Email = customer.CustomerEmail,
                                CreationDate = customer.CreationDate,
                                ModifiedDate = customer.ModifiedDate,
                                GarageID = customer.GarageID,
                                UserID = customer.UserID,
                                HomePhone = customer.CustomerHomePhone,
                                MobilePhone = customer.CustomerMobilePhone,
                                Comment = customer.CustomerComment,
                                // Populate additional properties from Users table
                                EnableAccess = (long)user.EnableAccess,
                                LastLoginDate = user.LastLoginDate,
                                Photo = customer.CustomerPhoto
                            };

                userViewModel = await query.FirstOrDefaultAsync();
            }else if (userType == 3)
            {
                // Query Engineer by ID
                var engineer = await dbContext.Engineer.FirstOrDefaultAsync(e => e.EngineerID == userID && e.GarageID == garageID);

                if (engineer == null)
                {
                    return NotFound();
                }

                // Query EngineerSpecialities for the given engineerID
                var engineerSpecialities = await dbContext.EngineerSpecialities
                    .Where(es => es.EngineerID == userID)
                    .Select(es => es.SpecialityID) // Select only the SpecialityID
                    .ToListAsync();

                // Query the table containing SpecialityDescription
                var specialities = await dbContext.EngineerSpeciality
                    .Where(sp => engineerSpecialities.Contains(sp.ID)) // Filter by SpecialityID
                    .Select(sp => new EngineerSpeciality
                    {
                        ID = sp.ID,
                        Speciality = sp.Speciality
                    })
                    .ToListAsync();

                var query = from engineerGet in dbContext.Engineer
                            join user in dbContext.Users
                on engineerGet.UserID equals user.ID
                            where engineerGet.EngineerID == userID && engineerGet.GarageID == garageID
                            select new EngineerViewModel
                            {
                                EngineerID = engineerGet.EngineerID,
                                EngineerSurname = engineerGet.EngineerSurname,
                                EngineerName = engineerGet.EngineerName,
                                EngineerEmail = engineerGet.EngineerEmail,
                                CreationDate = engineerGet.CreationDate,
                                ModifiedDate = engineerGet.ModifiedDate,
                                GarageID = engineerGet.GarageID,
                                UserID = engineerGet.UserID,
                                EngineerHomePhone = engineerGet.EngineerHomePhone,
                                EngineerMobilePhone = engineerGet.EngineerMobilePhone,
                                EngineerComment = engineerGet.EngineerComment,
                                // Populate additional properties from Users table
                                EnableAccess = (long)user.EnableAccess,
                                LastLoginDate = user.LastLoginDate,
                                EngineerPhoto = engineerGet.EngineerPhoto,
                                EngineerSpecialities = specialities
                            };

                var engineerViewModel = await query.FirstOrDefaultAsync();

                return Ok(engineerViewModel);
            }
            else
            {
                return NotFound();
            }

            if (userViewModel != null)
            {
                return Ok(userViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/SendEmailToUserByID/")]
        public async Task<IActionResult> SendEmailToUserByID(Email email)//, string subject, string message)9
        {
            var user = await dbContext.Users.FindAsync(email.ReceiverID);
            if (user != null)
            {
                Email tempEmail = new Email
                {
                    GarageID = 1,
                    SenderID = email.SenderID,
                    ReceiverID = email.ReceiverID,
                    Receiver = user.Email,
                    Subject = email.Subject,
                    Message = email.Message,
                    InsDate = DateTime.Now
                };
                await _emailSender.SendEmailAsync(tempEmail);

                return new ContentResult() { Content = "Successfully", StatusCode = (int)ResponseCode.Success };
                //return Ok(email);
            }
            return new ContentResult() { Content = "Failed", StatusCode = (int)ResponseCode.FailedEmail };
            //return Ok();
        }

        [HttpPost]
        [Route("api/SendEmailToUsers")]
        public async Task<IActionResult> SendEmailToUsers(Email email)//, string subject, string message)
        {
            List<string> recepients = new List<string>{ "alexandrostselios@gmail.com","atselios@classter.com" };
            List<Email> emailList = new List<Email>();
            var user = await dbContext.Users.FindAsync(email.ReceiverID);
            for (int i = 0; i < recepients.Count; i++)
            {

                //if (user != null)
                //{

                Email tempEmail = new Email
                {
                    ReceiverID = email.ReceiverID,
                    Receiver = recepients[i],
                    Subject = email.Subject,
                    Message = email.Message,
                    InsDate = DateTime.Now
                };
                emailList.Add(tempEmail);
                //return Ok(email);
                //}
            }
            await _emailSender.SendEmailToListAsync(emailList);
            return Ok();
        }

        [HttpDelete]
        [Route("api/DeleteUserByID/{id:long}")]
        public async Task<IActionResult> DeleteUserByID([FromRoute] long id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("api/UserAccountAccess/{id:long}/{enableAccess:int}")]
        public async Task<IActionResult> UserAccountAccess([FromRoute] long id, int enableAccess)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user != null)
            {
                user.EnableAccess = (EnableAccess)enableAccess;
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }
    }
}