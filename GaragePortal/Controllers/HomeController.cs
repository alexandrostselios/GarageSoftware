using GaragePortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GaragePortal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;


namespace GaragePortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            GetSessionProperties();
            return View();
        }

        public IActionResult Privacy()
        {
            GetSessionProperties();
            IEnumerable<UserModels> userModels = null;
            using (var client = new HttpClient())
            {
                Uri baseAddress = new Uri("https://localhost:44374/api");
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


            //return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
