using GaragePortalNewUI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System;
using GaragePortalNewUI.Enum;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Data;

namespace GaragePortalNewUI.Controllers
{
    public class CarManufacturersController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;
        private List<CarManufacturers> temp;

        public CarManufacturersController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            GetSessionProperties();
            IEnumerable<CarManufacturers> carManufacturers = GetCarManufacturers();
            return View(carManufacturers);
        }

        public IEnumerable<CarManufacturers> GetCarManufacturers()
        {
            IEnumerable<CarManufacturers> carManufacturers = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetCarManufacturers");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CarManufacturers>>();
                    readTask.Wait();
                    carManufacturers = readTask.Result;
                }
                else
                {
                    carManufacturers = Enumerable.Empty<CarManufacturers>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return carManufacturers;
        }

        public ActionResult GetCarManufacturersToList()
        {
            IEnumerable<CarManufacturers> carManufacturers = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetCarManufacturers");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CarManufacturers>>();
                    readTask.Wait();
                    carManufacturers = readTask.Result;
                }
                else
                {
                    carManufacturers = Enumerable.Empty<CarManufacturers>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return Json(carManufacturers);
        }

        public IActionResult EditCarManufacturerPartial(long id)
        {
            GetSessionProperties();
            var responseTask = client.GetAsync(client.BaseAddress);
            CarManufacturers carManufacturer = null;
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetCarManufacturerByID/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CarManufacturers>();
                    readTask.Wait();
                    carManufacturer = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return PartialView("_EditCarManufacturerPartial", carManufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCarManufacturerItem(long id, [Bind("ID,ManufacturerName")] CarManufacturers carManufacturer)
        {
            if (id != carManufacturer.ID)
            {
                return NotFound();
            }
            HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateCarManufacturerByID/" + carManufacturer.ID, carManufacturer).Result;

            return RedirectToAction("Settings", "Settings");
            //return View();
        }

        private void SetSessionProperties(UserViewModel dbUser)
        {
            UserType u = (UserType)System.Enum.Parse(typeof(UserType), dbUser.UserType.ToString());
            HttpContext.Session.SetString("UserType", u.ToString());
            HttpContext.Session.SetString("ID", dbUser.ID.ToString());
            HttpContext.Session.SetString("Name", dbUser.Name);
            HttpContext.Session.SetString("Surname", dbUser.Surname);
            HttpContext.Session.SetString("SuccessMessage", "null");
            HttpContext.Session.SetString("DeleteServiceItem", "SetServiceItemsController");
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
            ViewBag.DeleteServiceItem = HttpContext.Session.GetString("DeleteServiceItem");
        }
    }
}