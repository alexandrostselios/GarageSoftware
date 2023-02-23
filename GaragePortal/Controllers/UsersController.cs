using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GaragePortal.Enum;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.IO;

namespace GaragePortal.Models
{
    public class UsersController : Controller
    {
        //private readonly GarageManagementSoftwarePortalContext _context;

        Uri baseAddress = new Uri("https://localhost:7096/api");
        HttpClient client;
        public UsersController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            //_context = context;
            //_context = null;
        }

        public ActionResult Index()
        {
            GetSessionProperties();
            IEnumerable<Users> users = null;
            using (client)
            {
                var responseTask = client.GetAsync(client.BaseAddress + "/GetUsers/1");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Users>>();
                    readTask.Wait();
                    users = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..
                    users = Enumerable.Empty<Users>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(users);
        }

        public IActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        public async Task<IActionResult> LoginHelper([Bind("Email,Password")] Users loginUser)
        {
            IEnumerable<Users> users = null;
            Users u = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/GetLogin/"+loginUser.Email+"/"+loginUser.Password).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                using (client)
                {
                    var responseTask = client.GetAsync(client.BaseAddress + "/GetUserByEmailAndPassword/" + loginUser.Email + "/" + loginUser.Password);
                    responseTask.Wait();
                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Users>();
                        readTask.Wait();
                        u = readTask.Result;
                        SetSessionProperties(u);
                        return RedirectToAction("Index", "Users");
                    }
                    else //web api sent error response 
                    {
                        //log response status here..
                        users = Enumerable.Empty<Users>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        return RedirectToAction("Login", "Users");
                    }
                }
            }else if ((int)response.StatusCode == 801)
            {
                ModelState.AddModelError("", @"No such user or wrong email");
                return View("Login", loginUser);
            }else if ((int)response.StatusCode == 802)
            {
                ModelState.AddModelError("", @"Wrong Password.");
                return View("Login", loginUser);
            }else{
                ModelState.AddModelError("", @"This user has been blocked!!!");
                return View("Login", loginUser);
            }
        }

        public IActionResult Logout()
        {
            SetSessionProperties(new Users { UserType = (long) UserType.Guest, ID = -1, Name = "None", Surname = "None" });
            GetSessionProperties();
            return RedirectToAction("Login", "Users");
        }

        public IActionResult ViewCustomerCars(long id)
        {
            GetSessionProperties();
            string userID = string.Format(ViewBag.ID);
            if (userID == null)
            {
                return NotFound();
            }
            IEnumerable<UserModels> userCars = null;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetUserModelByUserID/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<UserModels>>();
            readTask.Wait();
            userCars = readTask.Result;

            if (userCars == null)
            {
                return NotFound();
            }
            return View(userCars);
        }

        public IActionResult ViewCarDetails(long id)
        {
            GetSessionProperties();
            if (id == null)
            {
                return NotFound();
            }
            IEnumerable<ServiceHistory> carServiceHsitory = null;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetCarServiceHistoryByUserModelsID/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<ServiceHistory>>();
            readTask.Wait();
            carServiceHsitory = readTask.Result;
            if (carServiceHsitory == null)
            {
                return NotFound();
            }
            return View(carServiceHsitory);
            //var users = null;
            //if (users == null)
            //{
            //    return NotFound();
            //}
            //return View(users);
        }

        //public IActionResult EditCarView(long id)
        //{
        //    return View();
        //}

        public IActionResult EditCar(long id,Colors color,int flag)
        {
            GetSessionProperties();
            IEnumerable<UserModels> userCars = null;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetUserModelsDetailsByUserOrCarID/" + id + "/" + 1);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<UserModels>>();
            readTask.Wait();
            userCars = readTask.Result;
            UserModels e = userCars.FirstOrDefault(c => c.ID == id);
            if(flag == 0)
            {
                e.Color = color;
            }
            
            JsonContent content = JsonContent.Create(e);

            responseTask = client.PostAsync(client.BaseAddress + "/PostUserModel/", content);
            return View();

        }
        //public async Task<IActionResult> MyProfile()
        //{
        //    GetSessionProperties();
        //    string userID = string.Format(ViewBag.ID);
        //    if (userID == null)
        //    {
        //        return NotFound();
        //    }

        //    var users = await _context.Users
        //        .FirstOrDefaultAsync(m => m.ID == long.Parse(userID));
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(users);
        //}

        public IActionResult Create()
        {
            GetSessionProperties();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,Surname,Email,Age,Password,ConfirmPassword,UserPhoto")] Users createUser, IFormFile Image)
        {
            GetSessionProperties();
            //if (ModelState.IsValid)
            if (!(createUser.Email is null) && ModelState.IsValid)
            {
                createUser.UserType = 2;
                createUser.CreationDate = DateTime.Now;
                createUser.EnableAccess = createUser.EnableAccess;
                using (var stream = new MemoryStream()) {
                    Image.CopyToAsync(stream);
                    byte[] temp = stream.ToArray();
                    createUser.UserPhoto = temp; 
                }
                string data = JsonConvert.SerializeObject(createUser);
                var contentdata = new StringContent(data);
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddUser/", createUser).Result;

                //_context.Add(createUser);
                //_context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(createUser);
        }

        public IActionResult EditProfile(long id)
        {
            GetSessionProperties();
            string userID = string.Format(ViewBag.ID);
            if (userID == null)
            {
                return NotFound();
            }

            return View(null);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,Name,Surname,Email,Age,Password,ConfirmPassword,UserType,CreationDate,ModifiedDate,LastLoginDate,ChangePassword,ConvertUser,EnableAccess")] Users editUser, IFormFile Image)
        {
            if (id != editUser.ID)
            {
                return NotFound();
            }

            using (var stream = new MemoryStream())
            {
                Image.CopyToAsync(stream);
                byte[] temp = stream.ToArray();
                editUser.UserPhoto = temp;
            }
            HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateUser/"+editUser.ID, editUser).Result;

                //var dbUser = await _context.Users.FindAsync(editUser.ID);
                //if (editUser.ChangePassword == false)
                //{
                //    editUser.Password = dbUser.Password;
                //}
                //if (editUser.ConvertUser == true)
                //{
                //    if (dbUser.UserType == UserType.Admin)
                //    {
                //        editUser.UserType = UserType.User;
                //    }
                //    else if (dbUser.UserType == UserType.User)
                //    {
                //        editUser.UserType = UserType.User;
                //    }
                //}
                //_context.Entry(dbUser).State = EntityState.Detached;
                //if (ModelState.IsValid)
                //{
                //    try
                //    {
                //        editUser.ModifiedDate = DateTime.Now;
                //        _context.Update(editUser);
                //        await _context.SaveChangesAsync();
                //    }
                //    catch (DbUpdateConcurrencyException)
                //    {
                //        if (!UsersExists(editUser.ID))
                //        {
                //            return NotFound();
                //        }
                //        else
                //        {
                //            throw;
                //        }
                //    }
                //    return RedirectToAction(nameof(Index));
                //}
                return RedirectToAction(nameof(Index));
            //return View(editUser);
        }

        //private bool UsersExists(long iD)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IActionResult> Delete(long id)
        //{
        //    GetSessionProperties();
        //    if (id == null)
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

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    GetSessionProperties();
        //    var users = _context.Users.Find(id);
        //    _context.Users.Remove(users);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        private void SetSessionProperties(Users dbUser)
        {
            UserType u = (UserType)System.Enum.Parse(typeof(UserType), dbUser.UserType.ToString());
            HttpContext.Session.SetString("UserType", u.ToString());
            HttpContext.Session.SetString("ID", dbUser.ID.ToString());
            HttpContext.Session.SetString("Name", dbUser.Name);
            HttpContext.Session.SetString("Surname", dbUser.Surname);
        }

        private void GetSessionProperties()
        {
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.ID = HttpContext.Session.GetString("ID");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Surname = HttpContext.Session.GetString("Surname");
        }
    }
}