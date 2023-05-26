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
using System.Runtime.ConstrainedExecution;
using Microsoft.Extensions.Localization;
using System.Resources;

namespace GaragePortal.Models
{
    public class UsersController : Controller
    {
        //Uri baseAddress = new Uri("https://garageapi20230516165317.azurewebsites.net/api");
        //Uri baseAddress = new Uri("https://alefhome.ddns.net:5002/api");
        Uri baseAddress = new Uri("https://localhost:7096/api");
        HttpClient client;

        public UsersController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
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

        public async Task<IActionResult> MyProfile()
        {
            GetSessionProperties();
            string userID = string.Format(ViewBag.ID);
            if (userID == null)
            {
                return NotFound();
            }

            return View();
        }

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

            return RedirectToAction(nameof(Index));
        }

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