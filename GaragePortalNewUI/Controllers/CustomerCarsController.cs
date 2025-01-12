﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GaragePortalNewUI.Models;
using GaragePortalNewUI.Enum;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Json;
using System.Net.Http;
using GaragePortalNewUI.Models;
using System.IO.Pipelines;
using Newtonsoft.Json;

namespace GaragePortalNewUI.Controllers
{
    public class CustomerCarsController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;

        public CustomerCarsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        // GET: UserModels
        public async Task<IActionResult> Index()
        {
            return null;
        }

        public async Task<IActionResult> ViewCustomerCars(long id)
        {
            //GetSessionProperties();
            string userID = id.ToString(); // No need for string.Format here
            if (string.IsNullOrEmpty(userID))
            {
                return NotFound();
            }
            HttpContext.Session.SetString("CustomerUserID", id.ToString());
            GetSessionProperties();

            IEnumerable<CustomerCars> userCars = null;
            try
            {
                var response = await client.GetAsync(client.BaseAddress + "/GetCustomerCarsByCustomerID/" + ViewBag.GarageID + "/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();
                }

                var jsonContent = await response.Content.ReadAsStringAsync();
                userCars = JsonConvert.DeserializeObject<List<CustomerCars>>(jsonContent);

                if (userCars == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500); // Internal Server Error
            }

            return View(userCars);
        }

        public IActionResult ViewServiceHistoryList(long garageID)
        {
            GetSessionProperties();
            //if (userID == null)
            //{
            //    return NotFound();
            //}
            IEnumerable<ServiceHistory> userCars = null;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetCarsServiceHistoryToList/" + garageID);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<ServiceHistory>>();
            readTask.Wait();
            userCars = readTask.Result;

            if (userCars == null)
            {
                return NotFound();
            }

            return View(userCars);
        }

        public IActionResult ViewCarDetails(long id, string? searchBy, string? searchValue)
        {
            HttpContext.Session.SetString("CarDetailsID", id.ToString());
            GetSessionProperties();
            if (string.IsNullOrEmpty(searchValue))
            {
                if (id == null)
                {
                    return NotFound();
                }
                //HttpContext.Session.SetString("CarDetailsID", id.ToString());
                
                IEnumerable<ServiceHistory> carServiceHsitory = null;
                var responseTask = client.GetAsync(client.BaseAddress + "/GetCarServiceHistoryByCustomerCarID/" + id);
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
            else
            {
                using (client)
                {
                    var responseTask = client.GetAsync(client.BaseAddress);
                    IEnumerable<ServiceHistory> carServiceHsitory = null;
                    if (searchBy.ToLower() == "all")
                    {
                        responseTask = client.GetAsync(client.BaseAddress + "/GetUserModelsServiceHistoryByValue/0/" + searchValue + '/' + ViewBag.GarageID);
                    }
                    else if (searchBy.ToLower() == "vin")
                    {
                        responseTask = client.GetAsync(client.BaseAddress + "/GetUserModelsServiceHistoryByValue/1/" + searchValue + '/' + ViewBag.GarageID);
                    }
                    else if (searchBy.ToLower() == "licence_plate")
                    {
                        responseTask = client.GetAsync(client.BaseAddress + "/GetUserModelsServiceHistoryByValue/2/" + searchValue + '/' + ViewBag.GarageID);
                    }
                    responseTask.Wait();
                    var result = responseTask.Result;
                    var readTask = result.Content.ReadAsAsync<IList<ServiceHistory>>();
                    readTask.Wait();
                    carServiceHsitory = readTask.Result;

                    return View(carServiceHsitory);
                }
            }
        }

        public IActionResult EditCarDetails(long id, Colors color, int flag, IFormFile Image)
        {
            GetSessionProperties();
            IEnumerable<CustomerCars> userCars = null;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetCustomerCarByCarID/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<CustomerCars>>();
            readTask.Wait();
            userCars = readTask.Result;
            CustomerCars e = userCars.FirstOrDefault(c => c.ID == id);
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
                ID = e.ID,
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
            cc.CarImage = e.CarImage;
            JsonContent content = JsonContent.Create(e);
            responseTask = client.PutAsync(client.BaseAddress + "/UpdateCustomerCar/" + id, content);

            return RedirectToAction("ViewCustomerCars", new { id = ViewBag.CustomerUserID , cacheBust = DateTime.UtcNow.Ticks });
            //return View(cc);
        }

        public IActionResult EditCarDetailsPartial(long id, Colors color, int flag, IFormFile Image)
        {
            GetSessionProperties();
            IEnumerable<CustomerCars> userCars = null;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetCustomerCarByCarID/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<CustomerCars>>();
            readTask.Wait();
            userCars = readTask.Result;
            CustomerCars e = userCars.FirstOrDefault(c => c.ID == id);
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
                ID = e.ID,
                CarImage = e.CarImage
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
            responseTask = client.PutAsync(client.BaseAddress + "/UpdateCustomerCar/" + id, content);

            return PartialView("_EditCarDetailsPartialView", cc);
        }

        private void GetSessionProperties()
        {
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.ID = HttpContext.Session.GetString("ID");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Surname = HttpContext.Session.GetString("Surname");
            ViewBag.CarDetailsID = HttpContext.Session.GetString("CarDetailsID");
            ViewBag.CustomerUserID = HttpContext.Session.GetString("CustomerUserID");
            ViewBag.CustomerCarID = HttpContext.Session.GetString("CustomerCarID");
            ViewBag.GarageID = HttpContext.Session.GetString("GarageID");
            ViewBag.SHID = HttpContext.Session.GetString("SHID");
            //ViewBag.CustomerID = HttpContext.Session.GetString("CustomerID");
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

        public IActionResult CreateCustomerCarPartial()
        {
            GetSessionProperties();
            return PartialView("_CreateCustomerCarPartial");
        }

        // POST: UserModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,ModelManufacturer,Model,ModelYear,LicencePlate,VIN,Color,Kilometer,GarageID,FuelType")] UserModelsDTO userModels)
        {
            //userModels.EngineTypeID = 1;
            GetSessionProperties();
            if (ModelState.IsValid && userModels.CustomerID > 0)
            {
                JsonContent content = JsonContent.Create(userModels);
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddCustomerCar/", userModels).Result;

                return RedirectToAction("ViewCustomerCars", "CustomerCars", new {id = userModels.CustomerID });
            }
            return View(userModels);
        }

        public IActionResult CreateUserModelServiceHistoryPartial()
        {
            GetSessionProperties();
            return PartialView("_CreateUserModelServiceHistoryPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUserModelServiceHistory(long UserModelsID, [Bind("UserModelsID", "Description", "ServiceDate", "ServiceKilometer", "EngineerID", "StartPrice", "DiscountPrice", "DiscountPercentage", "FinalPrice", "StartingDate", "StartingTime", "FinishingDate", "FinishingTime","GarageID", "ServiceItemsList")] ServiceHistoryDTO serviceHistoryDTO)
        {
            GetSessionProperties();
            if (ModelState.IsValid && serviceHistoryDTO.CustomerCarID > 0 && !(serviceHistoryDTO.ServiceDate is null))
            {
                JsonContent content = JsonContent.Create(serviceHistoryDTO);
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddUserModelServiceHistory/", serviceHistoryDTO).Result;

                return RedirectToAction("ViewCarDetails", new { id = serviceHistoryDTO.CustomerCarID });
            }
            return PartialView("_QuickCreateUserModelServiceHistoryPartial");
            //return View("CreateUserModelServiceHistory");
        }

        public IActionResult QuickCreateUserModelServiceHistoryPartial(long? customerID, long? customerCarID)
        {
            HttpContext.Session.SetString("CustomerUserID", customerID.ToString());
            HttpContext.Session.SetString("CustomerCarID", customerCarID.ToString());
            GetSessionProperties();
            return PartialView("_QuickCreateUserModelServiceHistoryPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuickCreateCustomerCarServiceHistory(long UserModelsID, [Bind("CustomerID","CustomerCarID", "Description", "ServiceDate", "ServiceKilometer", "EngineerID", "StartPrice", "DiscountPrice", "DiscountPercentage", "FinalPrice", "StartingDate", "StartingTime", "FinishingDate", "FinishingTime", "GarageID", "ServiceItemsList")] ServiceHistoryDTO serviceHistoryDTO)
        {
            GetSessionProperties();
            if (ModelState.IsValid && serviceHistoryDTO.CustomerCarID > 0 && !(serviceHistoryDTO.ServiceDate is null))
            {
                JsonContent content = JsonContent.Create(serviceHistoryDTO);
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddCustomerCarserviceHistory/", serviceHistoryDTO).Result;

                return RedirectToAction("ViewCarDetails", new { id = serviceHistoryDTO.CustomerCarID });
            }

            return View("CreateUserModelServiceHistory");
        }

        public IActionResult UserModelServiceHistoryInformationPartial(long id)
        {
            //GetSessionProperties();
            //IEnumerable<ServiceHistoryWithItemsDTO> serviceHistoryList = null;
            //var responseTask = client.GetAsync(client.BaseAddress + "/GetCarServiceHistoryByServiceHistoryID/" + id);
            //responseTask.Wait();
            //var result = responseTask.Result;
            //var readTask = result.Content.ReadAsAsync<IList<ServiceHistoryWithItemsDTO>>();
            //readTask.Wait();
            //serviceHistoryList = readTask.Result;
            //ServiceHistoryWithItemsDTO serviceHistory = new ServiceHistoryWithItemsDTO()
            //{
            //    ID = serviceHistoryList.ElementAt(0).ID,
            //    GarageID = serviceHistoryList.ElementAt(0).GarageID,
            //    ServiceDate = serviceHistoryList.ElementAt(0).ServiceDate,
            //    ServiceKilometer = serviceHistoryList.ElementAt(0).ServiceKilometer,
            //    EngineerID = serviceHistoryList.ElementAt(0).EngineerID,
            //    Description = serviceHistoryList.ElementAt(0).Description,
            //    StartPrice = serviceHistoryList.ElementAt(0).StartPrice,
            //    FinalPrice = serviceHistoryList.ElementAt(0).FinalPrice,
            //    ServiceItem = serviceHistoryList.ElementAt(0).ServiceItem,
            //    ServiceItemID = serviceHistoryList.ElementAt(0).ServiceItemID,
            //    ServiceItemDescription = serviceHistoryList.ElementAt(0).ServiceItemDescription
            //};

            HttpContext.Session.SetString("SHID", id.ToString());
            GetSessionProperties();
            return PartialView("_CustomerCarServiceHistoryInformationPartial");
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

        // GET: UserModels/DeleteUserModel/5
        public async Task<IActionResult> DeleteUserModel(int? id)
        {
            GetSessionProperties();
            if (id == null)
            {
                return NotFound();
            }
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/DeleteUserModel/" + id).Result;

            System.Threading.Thread.Sleep(1000);
            return RedirectToAction("ViewCustomerCars",new { id = ViewBag.CustomerUserID });
        }

        // GET: UserModels/DeleteUserModel/5
        public async Task<IActionResult> DeleteUserModelServiceHistory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/DeleteServiceHistoryByServiceHistoryID/" + id).Result;

            return View("ViewCarDetails");
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