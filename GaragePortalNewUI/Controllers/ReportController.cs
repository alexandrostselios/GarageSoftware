using AspNetCore.Reporting;
using GaragePortalNewUI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GaragePortalNewUI.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;

        public ReportController(IWebHostEnvironment webHostEnvironment)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            this._webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }


        // https://localhost:5000/Report/Download?garageID=1&template=customers
        // https://localhost:44348/report/pdf?garageID=1&template=Customers

        public async Task<IActionResult> Download(long garageID, string template)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(@Resources.SettingsResources.ReportUri);

            // Build URL with query parameters
            var url = $"report/pdf?garageID={garageID}&template={Uri.EscapeDataString(template)}";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                // Handle error, maybe return an error view or message
                return StatusCode((int)response.StatusCode, "Could not generate report PDF.");
            }

            // Read the PDF bytes from the response
            var pdfBytes = await response.Content.ReadAsByteArrayAsync();

            // Return the PDF file to the browser
            return File(pdfBytes, "application/pdf", $"{template}.pdf");
        }

        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\garage.rdl";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("GarageID", "1");

            
            ReportDataSource reportDataSource = new ReportDataSource();
            string s = null;
           
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetDefinition");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<UserViewModel>>();
                    readTask.Wait();
                    s = readTask.Result.ToString();
                    AspNetCore.Reporting.LocalReport localReport = new AspNetCore.Reporting.LocalReport(s);
                    var results = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
                    return File(results.MainStream, "application/pdf");
                    //localReport.LoadReportDefinition(new MemoryStream(Encoding.UTF8.GetBytes(s)));
                }
                //else
                //{
                //    var customers = Enumerable.Empty<Users>();
                //    localReport.AddDataSource("DataSet1", customers);
                //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                //}
            }
            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
           
            return Ok();
        }
    }
}
