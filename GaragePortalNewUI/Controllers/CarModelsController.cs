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
    public class CarModelsController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;
        private List<CarModelsController> temp;

        public CarModelsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            GetSessionProperties();
            IEnumerable<CarModels> carModels = GetCarModels();
            return View(carModels);
        }

        public IEnumerable<CarModels> GetCarModels()
        {
            IEnumerable<CarModels> carModels = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetCarModels");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CarModels>>();
                    readTask.Wait();
                    carModels = readTask.Result;
                }
                else
                {
                    carModels = Enumerable.Empty<CarModels>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return carModels;
        }

        public ActionResult GetCarModelsToList()
        {
            IEnumerable<CarModels> carManufacturers = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetCarModels");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CarModels>>();
                    readTask.Wait();
                    carManufacturers = readTask.Result;
                }
                else
                {
                    carManufacturers = Enumerable.Empty<CarModels>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return Json(carManufacturers);
        }

        public IActionResult EditCarModelPartial(long id)
        {
            GetSessionProperties();
            var responseTask = client.GetAsync(client.BaseAddress);
            CarModels carModel = null;
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetCarModelByID/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CarModels>();
                    readTask.Wait();
                    carModel = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return PartialView("_EditCarModelPartial", carModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCarModelItem(long id, [Bind("ID,ModelName")] CarModels carModel)
        {
            if (id != carModel.ID)
            {
                return NotFound();
            }
            HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateCarModel/" + carModel.ID, carModel).Result;

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