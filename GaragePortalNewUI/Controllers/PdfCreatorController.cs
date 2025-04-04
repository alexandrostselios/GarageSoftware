﻿using DinkToPdf;
using DinkToPdf.Contracts;
using GaragePortalNewUI.Enum;
using GaragePortalNewUI.Models;
using GaragePortalNewUI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace GaragePortalNewUI.Controllers
{
    public class PdfCreatorController : Controller
    {
        private readonly IConverter _converter;

        public PdfCreatorController(IConverter converter)
        {
            _converter = converter;
        }

        public FileResult CreatePDF(long entityType,long? userID,long? serviceHistoryID)
        {
            GetSessionProperties();
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 }
                //DocumentTitle = "Test PDF"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(entityType,  userID is null ? HttpContext.Session.GetString("CustomerUserID") : userID.ToString(), HttpContext.Session.GetString("Culture").ToString(), serviceHistoryID),
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = " Page [page] of [toPage]"},
                FooterSettings = { FontName = "Arial", FontSize = 9, Center = "Garage Management Software ©TseliosAlexandros\n"+ DateTime.Now.DayOfWeek + " " + DateTime.Now.Day.ToString("00") + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year + "  " + DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00")}
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);

            if (entityType == 1)
            {
                return File(file, "application/pdf", "Employees " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Millisecond + ".pdf");
            }
            else if (entityType == 2)
            {
                return File(file, "application/pdf", "Customers " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Millisecond + ".pdf");
            }
            else if (entityType == 3)
            {
                return File(file, "application/pdf", "Engineers " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Millisecond + ".pdf");
            }
            else if (entityType == 4)
            {
                return File(file, "application/pdf", "User Cars " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Millisecond + ".pdf");
            }
            else
            {

                //Convert File to Base64 string and send to Client.
                //string base64 = Convert.ToBase64String(file, 0, file.Length);
                //return Content(base64);
                return File(file, "application/pdf", "General " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Millisecond + ".pdf");
            }
            
        }

        private void GetSessionProperties()
        {
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.ID = HttpContext.Session.GetString("ID");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Surname = HttpContext.Session.GetString("Surname");
            ViewBag.CarDetailsID = HttpContext.Session.GetString("CarDetailsID");
            ViewBag.CustomerUserID = HttpContext.Session.GetString("CustomerUserID");
            ViewBag.Culture = HttpContext.Session.GetString("Culture");
            ViewBag.GarageID = HttpContext.Session.GetString("GarageID");
        }
    }
}