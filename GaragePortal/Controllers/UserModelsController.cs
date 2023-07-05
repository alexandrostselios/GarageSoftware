using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GaragePortal.Models;
using GaragePortal.Enum;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Json;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace GaragePortal.Controllers
{
    public class UserModelsController : Controller
    {
        //Uri baseAddress = new Uri("https://localhost:7096/api");
        //Uri baseAddress = new Uri("http://alefhome.ddns.net:8082/api");
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;

        public UserModelsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        // GET: UserModels
        public async Task<IActionResult> Index()
        {
            return null;
        }

        public IActionResult ViewCustomerCars(long id)
        {
            GetSessionProperties();
            string userID = string.Format(id.ToString());
            if (userID == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("CustomerUserID", id.ToString());
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
            HttpContext.Session.SetString("CarDetailsID",id.ToString());
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
        }

        public IActionResult EditCarDetails(long id, Colors color, int flag, IFormFile Image)
        {
            GetSessionProperties();
            IEnumerable<UserModels> userCars = null;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetUserModelByCarID/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<UserModels>>();
            readTask.Wait();
            userCars = readTask.Result;
            UserModels e = userCars.FirstOrDefault(c => c.ID == id);
            CustomerCars cc = new CustomerCars
            {
                Color = e.Color,
                Kilometer = e.Kilometer,
                LicencePlate = e.LicencePlate,
                ManufacturerName = e.ManufacturerName,
                ModelName = e.ModelName,
                ModelYear = e.ModelYear,
                UserID = e.UserID,
                VIN = e.VIN,
                id = e.ID
            };
            e.Color = color;
            if (!(Image is null))
            {
                using (var stream = new MemoryStream())
                {
                    Image.CopyToAsync(stream);
                    byte[] temp = stream.ToArray();
                    e.CarImage = temp;
                }
            }
            JsonContent content = JsonContent.Create(e);
            responseTask = client.PutAsync(client.BaseAddress + "/UpdateUserModel/" + id, content);

            return View(cc);
        }

        private void GetSessionProperties()
        {
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.ID = HttpContext.Session.GetString("ID");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Surname = HttpContext.Session.GetString("Surname");
            ViewBag.CarDetailsID = HttpContext.Session.GetString("CarDetailsID");
            ViewBag.CustomerUserID = HttpContext.Session.GetString("CustomerUserID");
        }

        // GET: UserModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return NotFound();
        }

        // GET: UserModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,ModelManufacturer,Model,ModelYear,LicencePlate,VIN,Color,Kilometer")] UserModelsDTO userModels)
        {
            GetSessionProperties();
            if (ModelState.IsValid && userModels.UserID > 0)
            {
                JsonContent content = JsonContent.Create(userModels);
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddUserModel/", userModels).Result;

                return RedirectToAction("ViewCustomerCars", "UserModels", new {id = userModels.UserID});
            }
            return View(userModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUserModelServiceHistory(long UserModelsID, [Bind("UserModelsID", "Description", "ServiceDate", "ServiceKilometer", "EngineerID", "StartPrice", "DiscountPrice", "DiscountPercentage", "FinalPrice", "StartingDate", "StartingTime", "FinishingDate", "FinishingTime")] ServiceHistoryDTO serviceHistoryDTO)
        {
            GetSessionProperties();
            if (ModelState.IsValid && serviceHistoryDTO.UserModelsID > 0 && !(serviceHistoryDTO.ServiceDate is null))
            {
                JsonContent content = JsonContent.Create(serviceHistoryDTO);
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddUserModelServiceHistory/", serviceHistoryDTO).Result;

                return View();
            }

            return View("CreateUserModelServiceHistory");
        }

        // GET: UserModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return NotFound();
        }

        // POST: UserModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,ModelID,ModelYear")] UserModels userModels)
        {
            if (id != userModels.ID)
            {
                return NotFound();
            }

            return NotFound();
        }

        // GET: UserModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return NotFound();
        }

        // POST: UserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelsExists(int id)
        {
            return true;
        }
    }
}
