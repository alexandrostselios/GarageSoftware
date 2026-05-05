using GaragePortalNewUI.Controllers;
using GaragePortalNewUI.Models;
using GaragePortalNewUI.Models.AppInformation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace GaragePortalNewUI.Helpers
{
    public static class HtmlHelpers
    {
        public static string IsActive(this IHtmlHelper htmlHelper, string controller, string action)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = routeData.Values["action"]?.ToString();
            var routeController = routeData.Values["controller"]?.ToString();

            if (string.IsNullOrEmpty(controller))
            {
                controller = "Home";
            }

            if (string.IsNullOrEmpty(action))
            {
                action = "Index";
            }

            return controller.Equals(routeController, StringComparison.OrdinalIgnoreCase)
                   && action.Equals(routeAction, StringComparison.OrdinalIgnoreCase)
                ? "active"
                : "";
        }

        public static string GetVersion(this IHtmlHelper htmlHelper)
        {
            Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
            HttpClient client = new HttpClient()
            {
                BaseAddress = baseAddress
            };

            IEnumerable<AppInformation> appInformation = null;
            using (client)
            {
                var garageId = htmlHelper.ViewContext.ViewData["GarageID"];

                var responseTask = client.GetAsync(client.BaseAddress + "/GetAppInformation/" + garageId); //replace with ViewBag garageID
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AppInformation>>();
                    readTask.Wait();
                    appInformation = readTask.Result;
                }
            }

            var assembly = Assembly.GetExecutingAssembly();
            var version = assembly.GetName().Version;
            var versionNew = appInformation.FirstOrDefault().MajorIncrementalNumber.ToString() + '.' + appInformation.FirstOrDefault().MinorIncrementalNumber.ToString() + '.' + appInformation.FirstOrDefault().PublishDate.ToString("ddMM");

            return versionNew;
        }
    }
}
