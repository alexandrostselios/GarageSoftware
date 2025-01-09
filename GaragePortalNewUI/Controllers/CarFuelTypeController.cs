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
    public class CarFuelTypeController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;
        private List<CarFuelTypeController> temp;

        public CarFuelTypeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            GetSessionProperties();
            IEnumerable<CarFuelType> carModels = GetCarFuelTypes();
            return View(carModels);
        }

        public IEnumerable<CarFuelType> GetCarFuelTypes()
        {
            IEnumerable<CarFuelType> carFuelTypes = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetCarEngineTypesToList");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CarFuelType>>();
                    readTask.Wait();
                    carFuelTypes = readTask.Result;
                }
                else
                {
                    carFuelTypes = Enumerable.Empty<CarFuelType>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return carFuelTypes;
        }

        public ActionResult GetCarFuelTypesToList()
        {
            IEnumerable<CarFuelType> carManufacturers = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetCarModels");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CarFuelType>>();
                    readTask.Wait();
                    carManufacturers = readTask.Result;
                }
                else
                {
                    carManufacturers = Enumerable.Empty<CarFuelType>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return Json(carManufacturers);
        }

        public IActionResult EditCarFuelTypePartial(long id)
        {
            GetSessionProperties();
            var responseTask = client.GetAsync(client.BaseAddress);
            CarFuelType carFuelType = null;
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetCarEngineTypeByID/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CarFuelType>();
                    readTask.Wait();
                    carFuelType = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return PartialView("_EditCarFuelTypePartial", carFuelType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCarFuelTypeItem(long id, [Bind("ID,FuelType,GarageID")] CarFuelType carFuelType)
        {
            if (id != carFuelType.ID)
            {
                return NotFound();
            }
            HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateCarEngineType/" + carFuelType.ID + '/'+ carFuelType.GarageID, carFuelType).Result;

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