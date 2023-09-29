using DinkToPdf;
using DinkToPdf.Contracts;
using GaragePortalNewUI.Enum;
using GaragePortalNewUI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GaragePortalNewUI.Controllers
{
    public class PdfCreatorController : Controller
    {
        private readonly IConverter _converter;

        public PdfCreatorController(IConverter converter)
        {
            _converter = converter;
        }

        public FileResult CreatePDF(long entityType)
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
                HtmlContent = TemplateGenerator.GetHTMLString(entityType,  HttpContext.Session.GetString("CustomerUserID"), HttpContext.Session.GetString("Culture").ToString()),
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = " Page [page] of [toPage]"},
                FooterSettings = { FontName = "Arial", FontSize = 9, Center = "Garage Management Software ©TseliosAlexandros\n"+ DateTime.Now.DayOfWeek + " " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "  " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Millisecond }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);

            if (entityType == 2)
            {
                return File(file, "application/pdf", "Customers " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Millisecond + ".pdf");
            }
            else if (entityType == 3)
            {
                return File(file, "application/pdf", "Engineers " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Millisecond + ".pdf");
            }
            else
            {
                return File(file, "application/pdf", "User Cars " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Millisecond + ".pdf");
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
        }
    }
}