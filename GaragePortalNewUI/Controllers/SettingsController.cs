﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GaragePortalNewUI.Enum;
using Microsoft.Extensions.Localization;
using GaragePortalNewUI.Controllers;

namespace GaragePortalNewUI.Models
{
    public class SettingsController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;

        public SettingsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Settings()
        {
            GetSessionProperties();
            return View();
        }

        public ActionResult SettingsPartialView(long id)
        {
            GetSessionProperties();
            if (id == 1)
            {
                HttpContext.Session.SetString("DeleteServiceItem", "ServiceItemIsDeleted");
                ServiceItemsController si = new ServiceItemsController();
                List<ServiceItems> temp = si.GetServiceItems().ToList();
                return PartialView("_ServiceItemsPartial", temp);
            }
            else if ( id==2 || id==5)
            {
                //HttpContext.Session.SetString("DeleteServiceItem", "ServiceItemIsDeleted");
                CarManufacturersController si = new CarManufacturersController();
                List<CarManufacturers> temp = si.GetCarManufacturers().ToList();
                return PartialView("_ManufacturersPartial", temp);
            }
            else if (id == 3)
            {
                CarModelsController si = new CarModelsController();
                List<CarModels> temp = si.GetCarModels().ToList();
                return PartialView("_ModelsPartial");
            }
            else if (id == 6)
            {
                return PartialView("_UtilitiesPartial");
            }
            else
            {
                return Ok();
            }
        }

        private void SetSessionProperties(UserViewModel dbUser)
        {
            UserType u = (UserType)System.Enum.Parse(typeof(UserType), dbUser.UserType.ToString());
            HttpContext.Session.SetString("UserType", u.ToString());
            HttpContext.Session.SetString("ID", dbUser.ID.ToString());
            HttpContext.Session.SetString("Name", dbUser.Name);
            HttpContext.Session.SetString("Surname", dbUser.Surname);
            HttpContext.Session.SetString("SuccessMessage", "null");
            HttpContext.Session.SetString("DeleteServiceItem", "SetSettingsController");
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