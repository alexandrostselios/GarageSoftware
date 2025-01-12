﻿using GaragePortal.Enum;
using GaragePortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace GaragePortal.Controllers
{
    public class EmailController : Controller
    {

        //Uri baseAddress = new Uri("https://garageapi20230516165317.azurewebsites.net/api");
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        //readonly Uri baseAddress = new Uri(@Resources.SettingsResources.UriProduction);
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

        public IActionResult SendEmailToUser(long id)
        {
            HttpContext.Session.SetString("ReceiverID", id.ToString());
            GetSessionProperties();
            return View();
            //return PartialView("SendEmailToUser");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEmail([Bind("ReceiverID,Subject,Message")] Email email)
        {
            GetSessionProperties();
            if (!(email.Message is null) && ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(email);
                var contentdata = new StringContent(data);
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/SendEmailToUserByID/", email).Result;

                return RedirectToAction("Index","Users");
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
        }
    }
}
