using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GaragePortalNewUI.Controllers
{
    public class UILanguageController : Controller
    {
        public IActionResult Index()
        {
            GetSessionProperties();
            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });
            SetSessionProperties(culture);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        private void SetSessionProperties(string culture)
        {
            if (culture == "en-GB")
            {
                HttpContext.Session.SetString("Language", "English");
                HttpContext.Session.SetString("Culture", "en-GB");
            }
            else if (culture == "el-GR")
            {
                HttpContext.Session.SetString("Language", "Ελληνικά");
                HttpContext.Session.SetString("Culture", "el-GR");
            }
            else if (culture == "de-DE")
            {
                HttpContext.Session.SetString("Language", "Deutch");
                HttpContext.Session.SetString("Culture", "de-DE");
            }
            HttpContext.Session.SetString("SuccessMessage", "null");
        }

        private void GetSessionProperties()
        {
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.ID = HttpContext.Session.GetString("ID");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Surname = HttpContext.Session.GetString("Surname");
        }
    }
}