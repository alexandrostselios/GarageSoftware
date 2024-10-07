using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GaragePortalNewUI.Enum;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.IO;
using Microsoft.Extensions.Localization;
using GaragePortalNewUI.Models;
using System.Resources;
using System.Globalization;
using System.Reflection;
using GaragePortalNewUI.ViewModels.Customer;

namespace GaragePortalNewUI.Controllers
{
    public class UsersController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;
        private readonly ResourceManager _resourceManager = new ResourceManager("GaragePortalNewUI.Resources.SharedResource", typeof(UsersController).Assembly);
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;

        public UsersController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        //public ActionResult Customers(string searchBy, string searchValue)
        //{
        //    GetSessionProperties();
        //    IEnumerable<UserViewModel> customers = null;
        //    var responseTask = client.GetAsync(client.BaseAddress);
        //    if (string.IsNullOrEmpty(searchValue))
        //    {
        //        using (client){
        //            responseTask = client.GetAsync(client.BaseAddress + "/GetCustomers" + "/" + ViewBag.GarageID);
        //            responseTask.Wait();
        //            var result = responseTask.Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                var readTask = result.Content.ReadAsAsync<IList<UserViewModel>>();
        //                readTask.Wait();
        //                customers = readTask.Result;
        //            }
        //            else
        //            {
        //                customers = Enumerable.Empty<UserViewModel>();
        //                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        using (client)
        //        {
        //            if (searchBy.ToLower() == "all")
        //            {
        //                responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/0/2/" + searchValue + '/' + ViewBag.GarageID);
        //            }
        //            else if (searchBy.ToLower() == "name")
        //            {
        //                responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/1/2/" + searchValue + '/' + ViewBag.GarageID); 
        //            }else if (searchBy.ToLower() == "surname")
        //            {
        //                responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/2/2/" + searchValue + '/' + ViewBag.GarageID);
        //            }else if (searchBy.ToLower() == "email")
        //            {
        //                responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/3/2/" + searchValue + '/' + ViewBag.GarageID);
        //            }
        //            responseTask.Wait();
        //            var result = responseTask.Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                var readTask = result.Content.ReadAsAsync<IList<UserViewModel>>();
        //                readTask.Wait();
        //                customers = readTask.Result;
        //            }
        //            else
        //            {
        //                customers = Enumerable.Empty<UserViewModel>();
        //                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //            }
        //        }
        //    }
        //    return View(customers);
        //}

        //public IEnumerable<UserViewModel> GetCustomersList()
        //{
        //    IEnumerable<UserViewModel> customersList = null;
        //    var responseTask = client.GetAsync(client.BaseAddress);
        //    using (client)
        //    {
        //        responseTask = client.GetAsync(client.BaseAddress + "/GetCustomers" + "/1"); /*+ ViewBag.GarageID);*/
        //        responseTask.Wait();
        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<IList<UserViewModel>>();
        //            readTask.Wait();
        //            customersList = readTask.Result;
        //        }
        //        else
        //        {
        //            customersList = Enumerable.Empty<UserViewModel>();
        //            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //        }
        //    }
        //    return customersList;
        //}

        //public ActionResult Engineers(string searchBy, string searchValue)
        //{
        //    GetSessionProperties();
        //    if (HttpContext.Session.GetString("SuccessMessage")!="null")
        //    {
        //        HttpContext.Session.SetString("SuccessMessage", "null");
        //    }
        //    IEnumerable<UserViewModel> engineers = null;
        //    var responseTask = client.GetAsync(client.BaseAddress);
        //    if (string.IsNullOrEmpty(searchValue))
        //    {
        //        using (client)
        //        {
        //            responseTask = client.GetAsync(client.BaseAddress + "/GetEngineers" + "/" + ViewBag.GarageID);
        //            responseTask.Wait();
        //            var result = responseTask.Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                var readTask = result.Content.ReadAsAsync<IList<UserViewModel>>();
        //                readTask.Wait();
        //                engineers = readTask.Result;
        //            }
        //            else
        //            {
        //                engineers = Enumerable.Empty<UserViewModel>();
        //                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        using (client)
        //        {
        //            if (searchBy.ToLower() == "all")
        //            {
        //                responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/0/3/" + searchValue + '/' + ViewBag.GarageID);
        //            }
        //            else if (searchBy.ToLower() == "name")
        //            {
        //                responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/1/3/" + searchValue + '/' + ViewBag.GarageID);
        //            }
        //            else if (searchBy.ToLower() == "surname")
        //            {
        //                responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/2/3/" + searchValue + '/' + ViewBag.GarageID);
        //            }
        //            else if (searchBy.ToLower() == "email")
        //            {
        //                responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/3/3/" + searchValue + '/' + ViewBag.GarageID);
        //            }
        //            responseTask.Wait();
        //            var result = responseTask.Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                var readTask = result.Content.ReadAsAsync<IList<UserViewModel>>();
        //                readTask.Wait();
        //                engineers = readTask.Result;
        //            }
        //            else
        //            {
        //                engineers = Enumerable.Empty<UserViewModel>();
        //                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //            }
        //        }
        //    }
        //    return View(engineers);
        //}

        //public IEnumerable<UserViewModel> GetEngineersList()
        //{
        //    IEnumerable<UserViewModel> engineersList = null;
        //    var responseTask = client.GetAsync(client.BaseAddress);
        //    using (client)
        //    {
        //        responseTask = client.GetAsync(client.BaseAddress + "/GetEngineers" + "/1"); /*+ ViewBag.GarageID);*/
        //        responseTask.Wait();
        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<IList<UserViewModel>>();
        //            readTask.Wait();
        //            engineersList = readTask.Result;
        //        }
        //        else
        //        {
        //            engineersList = Enumerable.Empty<UserViewModel>();
        //            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //        }
        //    }
        //    return engineersList;
        //}

        public IActionResult Login()
        {
            GetSessionProperties();
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> LoginHelper([Bind("Email,Password")] UserViewModel loginUser)
        {
            IEnumerable<UserViewModel> users = null;
            UserViewModel logInUser = null;

            //string host = HttpContext.Request.Host.Host.ToString();
            string host = "garagewebportal";
            // Add later + "/" + loginUser.GarageID

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/GetLogin/"+loginUser.Email+"/"+loginUser.Password + "/1" ).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                using (client)
                {
                    var responseTask = client.GetAsync(client.BaseAddress + "/GetUserByEmailAndPassword/" + loginUser.Email + "/" + loginUser.Password + "/1");
                    responseTask.Wait();
                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<UserViewModel>();
                        readTask.Wait();
                        logInUser = readTask.Result;
                        SetSessionProperties(logInUser);
                        logInUser.LastLoginDate = DateTime.Now;
                        HttpResponseMessage loginResponse = client.PutAsJsonAsync(client.BaseAddress + "/UpdateUser/" + logInUser.ID, logInUser).Result;

                        if(logInUser.UserType == (long) UserType.Admin)
                        {
                            return RedirectToAction("Customers", "Customer");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        users = Enumerable.Empty<UserViewModel>();
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
            SetSessionProperties(new UserViewModel { UserType = (long) UserType.Guest, ID = -1, Name = "None", Surname = "None" });
            GetSessionProperties();

            return RedirectToAction("Login", "Users");
        }

        public async Task<IActionResult> MyProfile()
        {
            GetSessionProperties();
            string userID = string.Format(ViewBag.ID);
            string garageID = string.Format(ViewBag.GarageID);

            long userType = (long)(UserType)System.Enum.Parse(typeof(UserType), ViewBag.UserType.ToString());
            if (userID == null)
            {
                return NotFound();
            }
            UserViewModel user = null;
            using (client)
            {
                var responseTask = client.GetAsync(client.BaseAddress + "/GetUserByID/" + userID +'/' + userType + '/' + garageID);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserViewModel>();
                    readTask.Wait();
                    user = (UserViewModel)readTask.Result;
                }
            }
            return View(user);
        }

        public IActionResult EditMyProfile(long id)
        {
            GetSessionProperties();
            string userID = string.Format(ViewBag.ID);
            string garageID = string.Format(ViewBag.GarageID);

            long userType = (long)(UserType)System.Enum.Parse(typeof(UserType), ViewBag.UserType.ToString());
            if (userID == null)
            {
                return NotFound();
            }
            UserViewModel user = null;
            using (client)
            {
                var responseTask = client.GetAsync(client.BaseAddress + "/GetUserByID/" + userID + '/' + userType + '/' + garageID);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserViewModel>();
                    readTask.Wait();
                    user = (UserViewModel)readTask.Result;
                }
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMyProfile(long id, [Bind("ID,Name,Surname,Email,Age,Password,ConfirmPassword,UserType,CreationDate,ModifiedDate,LastLoginDate,ChangePassword,ConvertUser,EnableAccess")] UserViewModel editCustomer, IFormFile Image)
        {
            GetSessionProperties();
            if (id != editCustomer.ID)
            {
                return NotFound();
            }

            if (!(editCustomer.UserPhoto is null))
            {
                using (var stream = new MemoryStream())
                {
                    Image.CopyToAsync(stream);
                    byte[] temp = stream.ToArray();
                    editCustomer.UserPhoto = temp;
                }
            }
            editCustomer.ModifiedDate = DateTime.Now;
            editCustomer.UserType = (long?)(UserType)System.Enum.Parse(typeof(UserType), ViewBag.UserType.ToString());
            HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateUser/" + editCustomer.ID, editCustomer).Result;

            if (editCustomer.UserType == (long)UserType.Admin)
            {
                return RedirectToAction("Customers", "Users");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult EditCustomerPartial(long id, long garageID)
        {
            GetSessionProperties();
            UserViewModel editCustomer;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetCustomerByID/" + id + "/" + garageID);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<UserViewModel>();
            readTask.Wait();
            editCustomer = readTask.Result;
            return PartialView("_EditCustomerPartialView", editCustomer);
        }

        public IActionResult EditEngineerPartial(long id, long garageID)
        {
            GetSessionProperties();
            UserViewModel editEngineer;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetEngineerByID/" + id + "/" + garageID);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<UserViewModel>();
            readTask.Wait();
            editEngineer = readTask.Result;
            return PartialView("_EditEngineerPartialView", editEngineer);
        }

        public IActionResult EditEngineerProfile(long id)
        {
            GetSessionProperties();
            string engineerID = string.Format(ViewBag.ID);
            if (engineerID == null)
            {
                return NotFound();
            }
            return View(null);
        }

        public IActionResult SendEmailToUser(long id)
        {
            GetSessionProperties();
            string customerID = string.Format(ViewBag.ID);
            if (customerID == null)
            {
                return NotFound();
            }
            SendEmailToUser(id, customerID);
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmailToUser(long userID,string test)
        {
            Email email = new Email
            {
                ReceiverID = userID,
                Subject  = "Subject Test",
                Message  = "Message Test"
            };
            HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/SendEmailToUserByID/", email).Result;

            return null;
        }

        private void SetSessionProperties(UserViewModel dbUser)
        {
            UserType u = (UserType)System.Enum.Parse(typeof(UserType), dbUser.UserType.ToString());
            HttpContext.Session.SetString("UserType", u.ToString());
            HttpContext.Session.SetString("ID", dbUser.ID.ToString());
            HttpContext.Session.SetString("Name", dbUser.Name);
            HttpContext.Session.SetString("Surname", dbUser.Surname);
            HttpContext.Session.SetString("SuccessMessage", "null");
            HttpContext.Session.SetString("GarageID", dbUser.GarageID.ToString());
            HttpContext.Session.SetString("DeleteServiceItem", "UsersController");
        }

        private void GetSessionProperties()
        {
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.ID = HttpContext.Session.GetString("ID");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Surname = HttpContext.Session.GetString("Surname");
            ViewBag.Culture = HttpContext.Session.GetString("Culture");
            ViewBag.GarageID = HttpContext.Session.GetString("GarageID");
            if (HttpContext.Session.GetString("Language") is null)
            {
                HttpContext.Session.SetString("Language", "English");
            }
            else
            {
                ViewBag.Language = HttpContext.Session.GetString("Language");
            }
            ViewBag.SuccessMessage = HttpContext.Session.GetString("SuccessMessage");
            ViewBag.GarageID = HttpContext.Session.GetString("GarageID");
            ViewBag.CustomerCreated = HttpContext.Session.GetString("CustomerCreated");
            ViewBag.CustomerCreatedInfo = HttpContext.Session.GetString("CustomerCreatedInfo");
            ViewBag.EngineerCreated = HttpContext.Session.GetString("EngineerCreated");
            ViewBag.EngineerCreatedInfo = HttpContext.Session.GetString("EngineerCreatedInfo");
        }

        [HttpPost]
        public ActionResult SetViewBag(string value)
        {
            HttpContext.Session.SetString("SuccessMessage", "null");
            HttpContext.Session.SetString("CustomerCreated", "null");
            HttpContext.Session.SetString("CustomerCreatedInfo", "null");
            HttpContext.Session.SetString("EngineerCreated", "null");
            HttpContext.Session.SetString("EngineerCreatedInfo", "null");
            HttpContext.Session.SetString("EmployeeCreated", "null");
            HttpContext.Session.SetString("EmployeeCreatedInfo", "null");
            return new EmptyResult();
        }
    }
}