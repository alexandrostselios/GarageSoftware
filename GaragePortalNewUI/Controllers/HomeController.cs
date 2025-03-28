﻿using GaragePortalNewUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GaragePortalNewUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Localization;
using GaragePortalNewUI.Enum;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;

namespace GaragePortalNewUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private bool isProduction = true;
        private bool isCustomer = false;

        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /* REMOVE IN PRODUCTION */

            if(!isProduction && !isCustomer) { 
                SetSessionPropertiesAdmin();
            }
            else if (!isProduction && isCustomer)
            {
                SetSessionPropertiesCustomer();
            }
            //else
            //{
            //    HttpContext.Session.SetString("Language", "Ελληνικά");
            //    HttpContext.Session.SetString("Culture", "el-GR");
            //    HttpContext.Session.SetString("GarageID", "1");
            //}

            /* REMOVE IN PRODUCTION */
            GetSessionProperties();
            return View();
        }

        public IActionResult Privacy()
        {
            GetSessionProperties();
            IEnumerable<UserModels> userModels = null;
            using (var client = new HttpClient())
            {
                Uri baseAddress = new Uri("https://localhost:7096/api");
                client.BaseAddress = baseAddress;
                var responseUserModels = client.GetAsync(client.BaseAddress + "/GetUserModelsByUserID/1");
                responseUserModels.Wait();
                var resultUserModels = responseUserModels.Result;
                if (resultUserModels.IsSuccessStatusCode)
                {
                    var readTaskUserModels = resultUserModels.Content.ReadAsAsync<IList<UserModels>>();
                    readTaskUserModels.Wait();
                    userModels = readTaskUserModels.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..
                    userModels = Enumerable.Empty<UserModels>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(userModels);
        }

        public IActionResult Settings()
        {
            GetSessionProperties();
            IEnumerable<UserModels> userModels = null;
            using (var client = new HttpClient())
            {
                //Uri baseAddress = new Uri("https://localhost:7096/api");
                client.BaseAddress = baseAddress;
                var responseUserModels = client.GetAsync(client.BaseAddress + "/GetUserModelsByUserID/1");
                responseUserModels.Wait();
                var resultUserModels = responseUserModels.Result;
                if (resultUserModels.IsSuccessStatusCode)
                {
                    var readTaskUserModels = resultUserModels.Content.ReadAsAsync<IList<UserModels>>();
                    readTaskUserModels.Wait();
                    userModels = readTaskUserModels.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..
                    userModels = Enumerable.Empty<UserModels>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(userModels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /* REMOVE IN PRODUCTION */

        private void SetSessionPropertiesAdmin()
        {

            UserType u = UserType.Admin;
            HttpContext.Session.SetString("UserType", u.ToString());
            HttpContext.Session.SetString("ID", "30");
            HttpContext.Session.SetString("Name", "Test1");
            HttpContext.Session.SetString("Surname", "Employee1");
            client.BaseAddress = baseAddress;
            IEnumerable<Settings> settings = null;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetSettings");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Settings>>();
                readTask.Wait();
                settings = readTask.Result;
            }
            var lang = settings.FirstOrDefault(x => x.Description == "Language").Value;
            HttpContext.Session.SetString("Culture", lang );
            HttpContext.Session.SetString("Language",
                HttpContext.Session.GetString("Culture") == "el-GR" ? "Ελληνικά" :
                (HttpContext.Session.GetString("Culture") == "en-GB" ? "English" : "Deutch"));

            HttpContext.Session.SetString("GarageID", "1");
        }

        private void SetSessionPropertiesCustomer()
        {

            UserType u = UserType.Customer;
            HttpContext.Session.SetString("UserType", u.ToString());
            HttpContext.Session.SetString("ID", "2");
            HttpContext.Session.SetString("Name", "Customer1");
            HttpContext.Session.SetString("Surname", "Test1");
            client.BaseAddress = baseAddress;
            IEnumerable<Settings> settings = null;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetSettings");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Settings>>();
                readTask.Wait();
                settings = readTask.Result;
            }
            var lang = settings.FirstOrDefault(x => x.Description == "Language").Value;
            HttpContext.Session.SetString("Culture", lang);
            HttpContext.Session.SetString("Language", (HttpContext.Session.GetString("Culture") == "el-GR") ? "Ελληνικά" : "English");

            HttpContext.Session.SetString("GarageID", "1");
        }

        /* REMOVE IN PRODUCTION */

        private void GetSessionProperties()
        {
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.ID = HttpContext.Session.GetString("ID");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Surname = HttpContext.Session.GetString("Surname");
            ViewBag.Culture = HttpContext.Session.GetString("Culture");
            ViewBag.Language = HttpContext.Session.GetString("Language");
            ViewBag.GarageID = HttpContext.Session.GetString("GarageID");
        }
    }
}