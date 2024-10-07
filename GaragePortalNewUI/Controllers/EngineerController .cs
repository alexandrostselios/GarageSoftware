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
using GaragePortalNewUI.ViewModels.Engineer;

namespace GaragePortalNewUI.Controllers
{
    public class EngineerController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;
        private readonly ResourceManager _resourceManager = new ResourceManager("GaragePortalNewUI.Resources.SharedResource", typeof(UsersController).Assembly);
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;

        public EngineerController ()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Engineers(string searchBy, string searchValue)
        {
            GetSessionProperties();
            if (HttpContext.Session.GetString("SuccessMessage") != "null")
            {
                HttpContext.Session.SetString("SuccessMessage", "null");
            }
            IEnumerable<EngineerViewModel> engineers = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            if (string.IsNullOrEmpty(searchValue))
            {
                using (client)
                {
                    responseTask = client.GetAsync(client.BaseAddress + "/GetEngineers" + "/" + ViewBag.GarageID);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<EngineerViewModel>>();
                        readTask.Wait();
                        engineers = readTask.Result;
                    }
                    else
                    {
                        engineers = Enumerable.Empty<EngineerViewModel>();
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
                        responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/0/3/" + searchValue + '/' + ViewBag.GarageID);
                    }
                    else if (searchBy.ToLower() == "name")
                    {
                        responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/1/3/" + searchValue + '/' + ViewBag.GarageID);
                    }
                    else if (searchBy.ToLower() == "surname")
                    {
                        responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/2/3/" + searchValue + '/' + ViewBag.GarageID);
                    }
                    else if (searchBy.ToLower() == "email")
                    {
                        responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/3/3/" + searchValue + '/' + ViewBag.GarageID);
                    }
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<EngineerViewModel>>();
                        readTask.Wait();
                        engineers = readTask.Result;
                    }
                    else
                    {
                        engineers = Enumerable.Empty<EngineerViewModel>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            return View(engineers);
        }

        public IEnumerable<EngineerViewModel> GetEngineersList()
        {
            IEnumerable<EngineerViewModel> engineersList = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetEngineersToList" + "/1"); /*+ ViewBag.GarageID);*/
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<EngineerViewModel>>();
                    readTask.Wait();
                    engineersList = readTask.Result;
                }
                else
                {
                    engineersList = Enumerable.Empty<EngineerViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return engineersList;
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
        public IActionResult CreateEngineerPartial([Bind("EngineerID,EngineerName,EngineerSurname,EngineerEmail,EngineerPassword,EngineerPhoto,EngineerSpecialities,GarageID")] AddEngineerViewModel createUser, IFormFile Image)
        {
            GetSessionProperties();
            if (!(createUser.EngineerEmail is null) && ModelState.IsValid)
            {
                //createUser.UserType = 3;
                createUser.CreationDate = DateTime.Now;
                createUser.EnableAccess = EnableAccess.Enable;
                createUser.EngineerPhoto = null;
                if (Image != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        Image.CopyToAsync(stream);
                        byte[] temp = stream.ToArray();
                        createUser.EngineerPhoto = temp;
                    }
                }
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddEngineer/", createUser).Result;

                string successMessageInfo;
                string successMessage;
                if (response.IsSuccessStatusCode)
                {
                    successMessageInfo = string.Format(_resourceManager.GetString("Engineer_Added_Successfully", culture), createUser.EngineerSurname, createUser.EngineerName);
                    successMessage = "Successfully";
                }
                else
                {
                    successMessageInfo = string.Format(_resourceManager.GetString("Engineer_Added_Failed", culture), createUser.EngineerSurname, createUser.EngineerName);
                    successMessage = "Failed";
                }

                HttpContext.Session.SetString("EngineerCreatedInfo", successMessageInfo);
                HttpContext.Session.SetString("EngineerCreated", successMessage);

                return RedirectToAction(nameof(Engineers));
            }
            return PartialView("_CreateCustomerPartialView", createUser);

            //return RedirectToAction(nameof(Customers));
            //return RedirectToAction(nameof(Index));
            // return View(createUser);
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

        public IActionResult EditEngineerPartial(long id, long garageID)
        {
            GetSessionProperties();
            EngineerViewModel editEngineer;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetEngineerByID/" + id + "/" + garageID);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<EngineerViewModel>();
            readTask.Wait();
            editEngineer = readTask.Result;
            return PartialView("_EditEngineerPartialView", editEngineer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEngineer(long engineerID, [Bind("EngineerID,EngineerName,EngineerSurname,EngineerEmail,CreationDate,ModifiedDate,LastLoginDate,EnableAccess,EngineerPassword,GarageID,EngineerSpecialitiesID")] UpdateEngineerViewModel editEngineer, IFormFile Image)
        {
            if (engineerID != editEngineer.EngineerID)
            {
                return NotFound();
            }
            if (!(editEngineer.EngineerPhoto is null))
            {
                using (var stream = new MemoryStream())
                {
                    Image.CopyToAsync(stream);
                    byte[] temp = stream.ToArray();
                    editEngineer.EngineerPhoto = temp;
                }
            }
            //editEngineer.UserType = 3;
            editEngineer.ModifiedDate = DateTime.Now;
            HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateEngineer/" + editEngineer.EngineerID, editEngineer).Result;

            return RedirectToAction(nameof(Engineers));
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
            return new EmptyResult();
        }
    }
}