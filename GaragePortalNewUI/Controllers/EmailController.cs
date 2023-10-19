using GaragePortalNewUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace GaragePortalNewUI.Controllers
{
    public class EmailController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;

        public EmailController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendEmailToUser(long id, long userType)
        {
            HttpContext.Session.SetString("ReceiverID", id.ToString());
            HttpContext.Session.SetString("ReceiverUserType", userType.ToString());
            GetSessionProperties();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEmail([Bind("ReceiverID,Subject,Message")] Email email)
        {
            GetSessionProperties();
            if (!(email.Message is null) && ModelState.IsValid)
            {
                email.SenderID = long.Parse(HttpContext.Session.GetString("ID"));
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/SendEmailToUserByID/", email).Result;
                if ((int)response.StatusCode == 200)
                {
                    HttpContext.Session.SetString("SuccessMessage", "Successfully"); 
                }
                else // if ((int)response.StatusCode == 804)
                {
                    HttpContext.Session.SetString("SuccessMessage", "Failed");
                }
                if(HttpContext.Session.GetString("ReceiverUserType") == "2")
                {
                    return RedirectToAction("Customers", "Users");
                }
                else
                {
                    return RedirectToAction("Engineers", "Users");
                }
            }
            return View(email);
        }

        private void GetSessionProperties()
        {
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.ID = HttpContext.Session.GetString("ID");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Surname = HttpContext.Session.GetString("Surname");
            ViewBag.Culture = HttpContext.Session.GetString("Culture");
            ViewBag.ReceiverID = HttpContext.Session.GetString("ReceiverID");
            ViewBag.SuccessMessage = HttpContext.Session.GetString("SuccessMessage");
            ViewBag.ReceiverUserType = HttpContext.Session.GetString("ReceiverUserType");
        }
    }
}