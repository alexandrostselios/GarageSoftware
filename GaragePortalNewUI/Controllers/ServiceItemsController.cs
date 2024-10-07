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

namespace GaragePortalNewUI.Models
{
    public class ServiceItemsController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;
        private ServiceItemsController si;
        private List<ServiceItems> temp;

        public ServiceItemsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            GetSessionProperties();
            IEnumerable<ServiceItems> serviceItems = GetServiceItems();
            return View(serviceItems); 
        }

        public IEnumerable<ServiceItems> GetServiceItems()
        {
            IEnumerable<ServiceItems> serviceItems = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetServiceItems");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ServiceItems>>();
                    readTask.Wait();
                    serviceItems = readTask.Result;
                }
                else
                {
                    serviceItems = Enumerable.Empty<ServiceItems>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return serviceItems;
        }

        public IActionResult AddServiceItemPartial()
        {
            GetSessionProperties();
            return PartialView("_AddServiceItemPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddServiceItem([Bind("ID,Description,GarageID,Price")] ServiceItems serviceItem)
        {
            GetSessionProperties();
            if (serviceItem.Description != null)
            {
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddServiceItem/", serviceItem).Result;
                si = new ServiceItemsController();
                temp = si.GetServiceItems().ToList();
                //serviceItem.Description = null;
                //serviceItem.Price = null;
                //serviceItem.GarageID = 0;
                //actionName, controllerName, routeValues
                return RedirectToAction("Settings", "Settings");
            }
            return NotFound();
        }

        public IActionResult EditServiceItemPartial(long id)
        {
            GetSessionProperties();
            var responseTask = client.GetAsync(client.BaseAddress);
            ServiceItems serviceItems = null;
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetServiceItemsByID/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ServiceItems>();
                    readTask.Wait();
                    serviceItems = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return PartialView("_EditServiceItemPartial", serviceItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditServiceItem(long id, [Bind("ID,Description,Price")] ServiceItems serviceItem)
        {
            if (id != serviceItem.ID)
            {
                return NotFound();
            }
            HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateServiceItemByID/" + serviceItem.ID, serviceItem).Result;

            return RedirectToAction("Settings", "Settings");
            //return View();
        }

        public async Task<IActionResult> DeleteServiceItem(int? id)
        {
            GetSessionProperties();
            if (id == null)
            {
                return NotFound();
            }
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/DeleteServiceItemByID/" + id).Result;
            
            si = new ServiceItemsController();
            temp = si.GetServiceItems().ToList();
            return RedirectToAction("Settings", "Settings");
            //return View("~/Views/Settings/Settings.cshtml", temp);
            //return View("~/Views/Settings/_ServiceItemsPartial.cshtml", temp);
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