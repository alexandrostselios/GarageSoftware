using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using System.Net;
using GarageAPI.Enum;
using GarageAPI.Models.User;
using NuGet.Protocol.Plugins;
using GarageAPI.Models;

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
        [Route("api/GetUsersExist/{id:long}")]
        public async Task<IActionResult> GetUsersExist([FromRoute] long id)
        {
            return Ok(dbContext.Users.Any(e => e.ID == id));
        }

        [HttpGet]
        [Route("api/GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await dbContext.Users.Where(c => c.UserType == Enum.UserType.Customer || c.UserType == Enum.UserType.Admin).ToListAsync());
        }

        [HttpGet]
        [Route("api/GetCustomerByID/{id:long}")]
        public async Task<IActionResult> GetCustomerByID([FromRoute] long id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("api/GetUserByEmailAndPassword/{email}/{password}")]
        public async Task<IActionResult> GetUserByEmailAndPassword([FromRoute] string email, string password)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(c => c.Email == email && c.Password == password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("api/GetLogin/{email}/{password}")]
        public async Task<IActionResult> GetLogin([FromRoute] string email, string password)
        {
            Users loginuser = await dbContext.Users.FirstOrDefaultAsync(c => c.Email == email && c.Password == password);
            if (loginuser == null)
            {
                return new ContentResult() { Content = "No such user or wrong email", StatusCode = (int)ResponseCode.NoUserFound };
            }
            else
            {
                if (loginuser.Password == password)
                {
                    if (loginuser.EnableAccess == EnableAccess.Enable)
                    {
                        return new ContentResult() { Content = "Login", StatusCode = (int) ResponseCode.Success };
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
        [Route("api/GetEngineers")]
        public async Task<IActionResult> GetEngineers()
        {
            string StoredProc = "exec GetEngineers";
            List<UsersDTO> carEngineers = await dbContext.UsersDTO.FromSqlRaw(StoredProc).ToListAsync();

            if (carEngineers == null)
            {
                return NotFound();
            }
            return Ok(carEngineers);
        }

        [HttpGet]
        [Route("api/GetEngineerByID/{id:long}")]
        public async Task<IActionResult> GetEngineerByID([FromRoute] long id)
        {
            var engineer = await dbContext.Users.FindAsync(id);
            if (engineer == null)
            {
                return NotFound();
            }
            return Ok(engineer);
        }

        [HttpGet]
        [Route("api/GetUsersByValue/{searchBy}/{usertype}/{value}")]
        public async Task<IActionResult> GetUsersByValue([FromRoute] int searchBy,int usertype, string value)
        {
            var user = new List<Users>();
            if (searchBy == 0 && usertype == 0)
            {
                user = await dbContext.Users.Where(c => c.Name.Contains(value) || c.Surname.Contains(value) || c.Email.Contains(value)).ToListAsync();
            }
            else if (searchBy == 0 && usertype == 3)
            {
                user = await dbContext.Users.Where(c => (c.Name.Contains(value) || c.Surname.Contains(value) || c.Email.Contains(value)) && c.UserType == UserType.Engineer).ToListAsync();
            }
            else if (searchBy == 1 && usertype == 0)
            {
                user = await dbContext.Users.Where(c => c.Name.Contains(value)).ToListAsync();
            }
            else if (searchBy == 1 && usertype == 3)
            {
                user = await dbContext.Users.Where(c => c.Name.Contains(value) && c.UserType == UserType.Engineer).ToListAsync();
            }
            else if (searchBy == 2 && usertype == 0)
            {
                user = await dbContext.Users.Where(c => c.Surname.Contains(value)).ToListAsync();
            }
            else if (searchBy == 2 && (usertype == 3))
            {
                user = await dbContext.Users.Where(c => c.Surname.Contains(value) && c.UserType == UserType.Engineer).ToListAsync();
            }
            else if(searchBy == 3 && usertype == 0)
            {
                user = await dbContext.Users.Where(c => c.Email.Contains(value)).ToListAsync();
            }
            else
            {
                user = await dbContext.Users.Where(c => c.Email.Contains(value) && c.UserType == UserType.Engineer).ToListAsync();
            }
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("api/AddCustomer")]
        public async Task<IActionResult> AddCustomer(AddUserRequest addUserRequest)
        {
            var user = new Users()
            {
                Name = addUserRequest.Name,
                Surname = addUserRequest.Surname,
                Email = addUserRequest.Email,  
                Password = addUserRequest.Password, 
                GarageID = addUserRequest.GarageID,
                CreationDate = addUserRequest.CreationDate,
                UserType = addUserRequest.UserType,
                EnableAccess = addUserRequest.EnableAccess,
                UserPhoto = addUserRequest.UserPhoto
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost]
        [Route("api/AddEngineer")]
        public async Task<IActionResult> AddEngineer(AddEngineerRequest addEngineerRequest)
        {
            var engineer = new Users()
            {
                Name = addEngineerRequest.Name,
                Surname = addEngineerRequest.Surname,
                Email = addEngineerRequest.Email,
                Password = addEngineerRequest.Password,
                GarageID = addEngineerRequest.GarageID,
                CreationDate = addEngineerRequest.CreationDate,
                UserType = addEngineerRequest.UserType,
                EnableAccess = addEngineerRequest.EnableAccess,
                UserPhoto = addEngineerRequest.UserPhoto,
                Speciality = addEngineerRequest.EngineerSpeciality
            };
            await dbContext.Users.AddAsync(engineer);
            await dbContext.SaveChangesAsync();

            return Ok(engineer);
        }

        //[HttpPost]
        //[Route("api/SendEmailToUser/{receiver}/{subject}/{message}")]
        //public async void SendEmailToUser(string receiver, string subject, string message)
        //{
        //    Email email = new Email { 
        //        //Receiver= receiver,
        //        Subject=subject,
        //        Message = message
        //    };

        //    await _emailSender.SendEmailAsync(email);
        //}

        [HttpPost]
        [Route("api/SendEmailToUserByID")]
        public async Task<IActionResult> SendEmailToUserByID(Email email)//, string subject, string message)
        {
            var user = await dbContext.Users.FindAsync(email.ReceiverID);
            if(user!=null)
            {
                Email tempEmail = new Email {
                   Receiver = user.Email,
                   Subject = email.Subject,
                   Message = email.Message
                };
                await _emailSender.SendEmailAsync(tempEmail);
                return Ok(email);
            }
            return Ok();
        }

        [HttpPut]
        [Route("api/UpdateUser/{id:long}")]
        public async Task<IActionResult> UpdateUser([FromRoute] long id, UpdateUserRequest updateUserRequest)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user != null)
            {
                if (!(updateUserRequest.Name is null )) user.Name = updateUserRequest.Name;
                if (!(updateUserRequest.Surname is null)) user.Surname = updateUserRequest.Surname;
                if (!(updateUserRequest.Email is null)) user.Email = updateUserRequest.Email;
                if (!(updateUserRequest.Password is null)) user.Password = updateUserRequest.Password;
                if (!(updateUserRequest.LastLoginDate is null)) user.LastLoginDate = updateUserRequest.LastLoginDate;
                if (!(updateUserRequest.ModifiedDate is null)) user.ModifiedDate = updateUserRequest.ModifiedDate;
                if (updateUserRequest.UserType == UserType.Engineer) if (!(updateUserRequest.EngineerSpeciality is null)) user.Speciality = updateUserRequest.EngineerSpeciality;
                if (!(updateUserRequest.UserPhoto is null)) user.UserPhoto = updateUserRequest.UserPhoto;
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
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
    }
}