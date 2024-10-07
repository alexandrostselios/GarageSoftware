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
    public class CustomerController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;
        private readonly ResourceManager _resourceManager = new ResourceManager("GaragePortalNewUI.Resources.SharedResource", typeof(UsersController).Assembly);
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;

        public CustomerController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Customers(string searchBy, string searchValue)
        {
            GetSessionProperties();
            IEnumerable<CustomerViewModel> customers = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            if (string.IsNullOrEmpty(searchValue))
            {
                using (client){
                    responseTask = client.GetAsync(client.BaseAddress + "/GetCustomersToList" + "/" + ViewBag.GarageID);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<CustomerViewModel>>();
                        readTask.Wait();
                        customers = readTask.Result;
                    }
                    else
                    {
                        customers = Enumerable.Empty<CustomerViewModel>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            else
            {
                using (client)
                {
                    if (searchBy.ToLower() == "all")
                    {
                        responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/0/2/" + searchValue + '/' + ViewBag.GarageID);
                    }
                    else if (searchBy.ToLower() == "name")
                    {
                        responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/1/2/" + searchValue + '/' + ViewBag.GarageID); 
                    }else if (searchBy.ToLower() == "surname")
                    {
                        responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/2/2/" + searchValue + '/' + ViewBag.GarageID);
                    }else if (searchBy.ToLower() == "email")
                    {
                        responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/3/2/" + searchValue + '/' + ViewBag.GarageID);
                    }
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<CustomerViewModel>>();
                        readTask.Wait();
                        customers = readTask.Result;
                    }
                    else
                    {
                        customers = Enumerable.Empty<CustomerViewModel>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            return View(customers);
        }

        public IEnumerable<CustomerViewModel> GetCustomersList()
        {
            IEnumerable<CustomerViewModel> customersList = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetCustomersToList" + "/1"); /*+ ViewBag.GarageID);*/
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CustomerViewModel>>();
                    readTask.Wait();
                    customersList = readTask.Result;
                }
                else
                {
                    customersList = Enumerable.Empty<CustomerViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return customersList;
        }

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

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/GetLogin/"+loginUser.Email+"/"+loginUser.Password ).Result;
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
                        var readTask = result.Content.ReadAsAsync<UserViewModel>();
                        readTask.Wait();
                        logInUser = readTask.Result;
                        SetSessionProperties(logInUser);
                        logInUser.LastLoginDate = DateTime.Now;
                        HttpResponseMessage loginResponse = client.PutAsJsonAsync(client.BaseAddress + "/UpdateUser/" + logInUser.ID, logInUser).Result;

                        if(logInUser.UserType == (long) UserType.Admin)
                        {
                            return RedirectToAction("Customers", "Users");
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
            if (userID == null)
            {
                return NotFound();
            }
            UserViewModel user = null;
            using (client)
            {
                var responseTask = client.GetAsync(client.BaseAddress + "/GetCustomerByID/" + userID);
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

        public IActionResult CreateCustomer()
        {
            GetSessionProperties();
            return View();
        }

        public IActionResult CreateCustomerPartial()
        {
            GetSessionProperties();
            return PartialView("_CreateCustomerPartialView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCustomer([Bind("ID,Name,Surname,Email,Age,Password,ConfirmPassword,UserPhoto")] UserViewModel createUser, IFormFile Image)
        {
            GetSessionProperties();
            if (!(createUser.Email is null) && ModelState.IsValid)
            {
                createUser.UserType = 2;
                createUser.CreationDate = DateTime.Now;
                createUser.EnableAccess = EnableAccess.Enable;
                using (var stream = new MemoryStream()) {
                    Image.CopyToAsync(stream);
                    byte[] temp = stream.ToArray();
                    createUser.UserPhoto = temp; 
                }
                string data = JsonConvert.SerializeObject(createUser);
                var contentdata = new StringContent(data);
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddCustomer/", createUser).Result;

                return RedirectToAction(nameof(Customers));
            }
            //return RedirectToAction(nameof(Index));
            return View(createUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCustomerPartial([Bind("ID,CustomerName,CustomerSurname,CustomerEmail,Age,CustomerPassword,ConfirmPassword,CustomerPhoto,CustomerMobilePhone,CustomerHomePhone,GarageID")] CustomerViewModel createUser, IFormFile Image)
        {
            GetSessionProperties();
            if (!(createUser.CustomerEmail is null) && ModelState.IsValid)
            {
                createUser.UserType = (UserType)2;
                createUser.CreationDate = DateTime.Now;
                createUser.EnableAccess = EnableAccess.Enable;
                createUser.CustomerPhoto = null;
                if (Image != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        Image.CopyToAsync(stream);
                        byte[] temp = stream.ToArray();
                        createUser.CustomerPhoto = temp;
                    }
                }
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddCustomer/", createUser).Result;

                string successMessageInfo;
                string successMessage;
                if (response.IsSuccessStatusCode)
                {
                    successMessageInfo = string.Format(_resourceManager.GetString("Customer_Added_Successfully", culture), createUser.CustomerSurname, createUser.CustomerName);
                    successMessage = "Successfully";
                }
                else
                {
                    successMessageInfo = string.Format(_resourceManager.GetString("Customer_Added_Failed", culture), createUser.CustomerSurname, createUser.CustomerName);
                    successMessage = "Failed";
                }

                HttpContext.Session.SetString("CustomerCreatedInfo", successMessageInfo);
                HttpContext.Session.SetString("CustomerCreated", successMessage);

                return RedirectToAction(nameof(Customers));
            }
            return PartialView("_CreateCustomerPartialView", createUser);

            //return RedirectToAction(nameof(Customers));
            //return RedirectToAction(nameof(Index));
            // return View(createUser);
        }

        public IActionResult CreateEngineerPartial()
        {
            GetSessionProperties();
            return PartialView("_CreateEngineerPartialView");
        }

        public IActionResult CreateEngineer()
        {
            GetSessionProperties();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEngineer([Bind("ID,Name,Surname,Email,Age,Password,ConfirmPassword,UserPhoto,EngineerSpeciality")] UserViewModel createEngineer, IFormFile Image)
        {
            GetSessionProperties();
            if (!(createEngineer.Email is null) && ModelState.IsValid)
            {
                createEngineer.UserType = 3;
                createEngineer.CreationDate = DateTime.Now;
                createEngineer.EnableAccess = EnableAccess.Enable;
                if (!(createEngineer.UserPhoto is null))
                {
                    using (var stream = new MemoryStream())
                    {
                        Image.CopyToAsync(stream);
                        byte[] temp = stream.ToArray();
                        createEngineer.UserPhoto = temp;
                    }
                }
                string data = JsonConvert.SerializeObject(createEngineer);
                var contentdata = new StringContent(data);
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddEngineer/", createEngineer).Result;

                return RedirectToAction(nameof(Index));
            }
            return View(createEngineer);
        }

        public IActionResult EditCustomerProfile(long id)
        {
            GetSessionProperties();
            string customerID = string.Format(ViewBag.ID);
            if (customerID == null)
            {
                return NotFound();
            }
            return View(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCustomer(long customerID, [Bind("CustomerID,CustomerName,CustomerSurname,CustomerEmail,CustomerPhoto,CreationDate,CustomerMobilePhone,ModifiedDate,LastLoginDate,EnableAccess,GarageID")] CustomerViewModel editCustomer, IFormFile Image)
        {
            if (customerID != editCustomer.CustomerID)
            {
                return NotFound();
            }

            //if (!(editCustomer.CustomerPhoto is null))
            //{
            //    using (var stream = new MemoryStream())
            //    {
            //        Image.CopyToAsync(stream);
            //        byte[] temp = stream.ToArray();
            //        editCustomer.CustomerPhoto = temp;
            //    }
            //}

            if (!(Image is null))
            {
                using (var stream = new MemoryStream())
                {
                    Image.CopyToAsync(stream);
                    byte[] temp = stream.ToArray();
                    editCustomer.CustomerPhoto = temp;
                }
            }

            editCustomer.ModifiedDate = DateTime.Now;
            HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateCustomer/" + editCustomer.CustomerID, editCustomer).Result;

            return RedirectToAction(nameof(Customers));
        }

        public IActionResult EditMyProfile(long id)
        {
            GetSessionProperties();
            string customerID = string.Format(ViewBag.ID);
            if (customerID == null)
            {
                return NotFound();
            }
            return View(null);
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
            CustomerViewModel editCustomer;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetCustomerByID/" + id + "/" + garageID);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<CustomerViewModel>();
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
            ViewBag.EmployeeCreated = HttpContext.Session.GetString("EmployeeCreated");
            ViewBag.EmployeeCreatedInfo = HttpContext.Session.GetString("EmployeeCreatedInfo");
        }

        [HttpPost]
        public ActionResult SetViewBag(string value)
        {
            HttpContext.Session.SetString("SuccessMessage", "null");
            HttpContext.Session.SetString("CustomerCreated", "null");
            HttpContext.Session.SetString("CustomerCreatedInfo", "null");
            HttpContext.Session.SetString("EngineerCreated", "null");
            HttpContext.Session.SetString("EngineerCreatedInfo", "null");
            return new EmptyResult();
        }
    }
}