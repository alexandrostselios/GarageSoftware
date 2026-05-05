using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net.Http;
using System;
using System.Resources;
using GaragePortalNewUI.ViewModels.Employee;
using Microsoft.AspNetCore.Http;
using GaragePortalNewUI.Models;

namespace GaragePortalNewUI.Controllers
{
    public class GarageDetailsController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;
        private readonly ResourceManager _resourceManager = new ResourceManager("GaragePortalNewUI.Resources.SharedResource", typeof(UsersController).Assembly);
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;

        public GarageDetailsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult EditGarageDetails([Bind("ID,Description,isActive,Domain,LegalName,VATNumber,VATOffice,Country,Region,City,Address,ZipCode,PhoneNumber,Email,Website")] GarageDetails garageDetails)
        {
            try
            {
                GetSessionProperties();
                garageDetails.ModifyDate = DateTime.Now;
                HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateGarageDetails/" + garageDetails.ID, garageDetails).Result;
                if (response.IsSuccessStatusCode){
                    return Json(new { success = true, message = "Garage details updated successfully!" });
                }else{
                    return Json(new { success = false, message = "Failed to update garage details." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
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
    }
}