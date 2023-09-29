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
        //Uri baseAddress = new Uri("https://garageapi20230516165317.azurewebsites.net/api");
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        //readonly Uri baseAddress = new Uri(@Resources.SettingsResources.UriProduction);
        readonly HttpClient client;

        public ServiceItemsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            GetSessionProperties();
            IEnumerable<ServiceItems> serviceItems = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client){
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
            return View(serviceItems);
        }


        private void SetSessionProperties(Users dbUser)
        {
            UserType u = (UserType)System.Enum.Parse(typeof(UserType), dbUser.UserType.ToString());
            HttpContext.Session.SetString("UserType", u.ToString());
            HttpContext.Session.SetString("ID", dbUser.ID.ToString());
            HttpContext.Session.SetString("Name", dbUser.Name);
            HttpContext.Session.SetString("Surname", dbUser.Surname);
            HttpContext.Session.SetString("SuccessMessage", "null");
        }

        private void GetSessionProperties()
        {
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.ID = HttpContext.Session.GetString("ID");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Surname = HttpContext.Session.GetString("Surname");
            ViewBag.Culture = HttpContext.Session.GetString("Culture");
            if(HttpContext.Session.GetString("Language") is null)
            {
                HttpContext.Session.SetString("Language", "English");
            }
            else
            {
                ViewBag.Language = HttpContext.Session.GetString("Language");
            }
            ViewBag.SuccessMessage = HttpContext.Session.GetString("SuccessMessage");
        }
    }
}
