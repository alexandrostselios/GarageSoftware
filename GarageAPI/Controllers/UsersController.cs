using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using GarageAPI.Models;
using System.Net;
using GarageAPI.Enum;


namespace GarageAPI.Controllers
{
    [ApiController]
    public class UsersController : Controller
    {
        private readonly GarageAPIDbContext dbContext;

        public UsersController(GarageAPIDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("api/GetUsersExist/{id:long}")]
        public async Task<IActionResult> GetUsersExist([FromRoute] long id)
        {
            return Ok(dbContext.Users.Any(e => e.ID == id));
        }

        [HttpGet]
        [Route("api/GetUsers/{flag:long}")]
        public async Task<IActionResult> GetUsers([FromRoute] long flag)
        {
            if(flag == 0)
            {
                return Ok(await dbContext.Users.ToListAsync());
            }
            return Ok(await dbContext.Users.Where(c => c.UserType == Enum.UserType.Customer || c.UserType == Enum.UserType.Admin).ToListAsync());

        }

        [HttpGet]
        [Route("api/GetUserByID/{id:long}")]
        public async Task<IActionResult> GetUserByID([FromRoute] long id)
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
            var carEngineers = await dbContext.Users.Where(c => c.UserType == UserType.Engineer).ToListAsync();
            List<Users> carEngineersList = new List<Users>();
            for (int i = 0; i < carEngineers.Count; i++)
            {
               // carEngineersList.Add(await dbContext.CarModels.Where(x => x.ID == carEngineers[i].ID).FirstOrDefaultAsync());
            }
            if (carEngineers == null)
            {
                return NotFound();
            }
            return Ok(carEngineers.OrderBy(x => x.Surname));
        }

        //// GET: Users/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || dbContext.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var users = await dbContext.Users
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(users);
        //}

        //// GET: Users/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Users/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Name,Surname,Email,Password,UserType,CreationDate,ModifiedDate,LastLoginDate,EnableAccess")] Users users)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(users);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(users);
        //}

        //// GET: Users/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var users = await _context.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(users);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Surname,Email,Password,UserType,CreationDate,ModifiedDate,LastLoginDate,EnableAccess")] Users users)
        //{
        //    if (id != users.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(users);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UsersExists(users.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(users);
        //}

        //// GET: Users/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var users = await _context.Users
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(users);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Users == null)
        //    {
        //        return Problem("Entity set 'GarageAPIDbContext.Users'  is null.");
        //    }
        //    var users = await _context.Users.FindAsync(id);
        //    if (users != null)
        //    {
        //        _context.Users.Remove(users);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        [Route("api/AddUser")]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {
            var user = new Users()
            {
                Name = addUserRequest.Name,
                Surname = addUserRequest.Surname,
                Email = addUserRequest.Email,  
                Password = addUserRequest.Password, 
                GarageID = 0,
                CreationDate = DateTime.Now,
                UserType = UserType.Customer,
                EnableAccess = EnableAccess.Enable,
                UserPhoto = addUserRequest.UserPhoto
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
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
                //user.Password = updateUserRequest.Password;
                if (!(updateUserRequest.UserPhoto is null)) user.UserPhoto = updateUserRequest.UserPhoto;
                //user.UserPhoto = updateUserRequest.UserPhoto;
                //user.EnableAccess = updateUserRequest.EnableAccess;
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }
    }
}