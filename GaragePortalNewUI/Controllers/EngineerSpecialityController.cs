using GaragePortalNewUI.Models.EngineerSpeciality;
using GaragePortalNewUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using GaragePortalNewUI.Enum;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace GaragePortalNewUI.Controllers
{
    public class EngineerSpecialityController : Controller
    {

        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;

        public EngineerSpecialityController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            GetSessionProperties();
            IEnumerable<EngineerSpeciality> engineerSpecialities = GetEngineerSpecialities();
            return View(engineerSpecialities);
        }

        public IEnumerable<EngineerSpeciality> GetEngineerSpecialities()
        {
            IEnumerable<EngineerSpeciality> engineerSpecialities = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetEngineerSpeciality");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<EngineerSpeciality>>();
                    readTask.Wait();
                    engineerSpecialities = readTask.Result;
                }
                else
                {
                    engineerSpecialities = Enumerable.Empty<EngineerSpeciality>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return engineerSpecialities;
        }

        public IActionResult AddEngineerSpecialityPartial()
        {
            GetSessionProperties();
            return PartialView("_AddEngineerSpecialityPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEngineerSpeciality([Bind("Speciality,GarageID")] EngineerSpeciality engineerSpeciality)
        {
            GetSessionProperties();
            if (engineerSpeciality.Speciality != null)
            {
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddEngineerSpeciality/", engineerSpeciality).Result;
                return RedirectToAction("Settings", "Settings");
            }
            return NotFound();
        }

        public IActionResult EditEngineerSpecialityPartial(long id)
        {
            GetSessionProperties();
            var responseTask = client.GetAsync(client.BaseAddress);
            EngineerSpeciality engineerSpeciality = null;
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetEngineerSpecialityByID/" + id + "/" + ViewBag.GarageID);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EngineerSpeciality>();
                    readTask.Wait();
                    engineerSpeciality = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return PartialView("_EditEngineerSpecialityPartial", engineerSpeciality);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEngineerSpeciality(long id, [Bind("ID,Speciality,GarageID")] EngineerSpeciality engineerSpeciality)
        {
            if (id != engineerSpeciality.ID)
            {
                return NotFound();
            }
            HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateEngineerSpecialityByID/" + engineerSpeciality.ID + '/' + engineerSpeciality.GarageID, engineerSpeciality).Result;

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