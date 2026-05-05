using Microsoft.AspNetCore.Mvc;
using DinkToPdf;
using DinkToPdf.Contracts;
using ReportAPI.Models;
using ReportAPI.Services;
using GaragePortalNewUI.Models.EngineerSpeciality;
using System.Text.Json;

namespace ReportAPI.Controllers
{
    public class ReportController : Controller
    {
        private readonly IConverter _converter;
        private readonly ReportService _reportService;

        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;

        public ReportController(IConverter converter, ReportService reportService)
        {
            _converter = converter;
            _reportService = reportService;

            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        [HttpGet("/report/pdf")]
        public async Task<IActionResult> GeneratePdf([FromQuery] long garageID, [FromQuery] string template)
        {
            var html = "";
            var templateJson = "";
            string razorHtml = "";
            
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            HtmlToPdfDocument doc = null;
            using (client)
            {
                var responseTask = client.GetAsync(client.BaseAddress);
                if (template == "Customers")
                {
                    IEnumerable<Customer> customers = null;
                    
                    responseTask = client.GetAsync(client.BaseAddress + "/GetCustomersToList" + "/" + garageID);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadFromJsonAsync<IList<Customer>>();
                        readTask.Wait();
                        customers = readTask.Result;
                    }
                    else
                    {
                        customers = Enumerable.Empty<Customer>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }

                    templateJson = await _reportService.GetTemplateHtmlFromApiAsync(template, 1);
                    var templates = JsonSerializer.Deserialize<List<ReportDefinition>>(templateJson, options);

                    // Make sure there's at least one template
                    razorHtml = templates?.FirstOrDefault()?.Definition
                                       ?? throw new Exception("Template not found in API response.");

                    string commonUsings = "@using System.Linq\n@using System.Collections.Generic\n";
                    string finalTemplate = commonUsings + razorHtml;

                    html = await _reportService.RenderHtmlFromTemplateAsync(finalTemplate, customers);


                    //html = await _reportService.RenderViewToStringAsync(ControllerContext, template, customers);

                    doc = new HtmlToPdfDocument()
                    {
                        GlobalSettings = {
                            PaperSize = PaperKind.A4,
                            Orientation = Orientation.Portrait,
                            DocumentTitle = $"{template}_{garageID}_{DateTime.Now}" // <-- This sets the internal title
                        },
                        Objects = {
                            new ObjectSettings()
                            {
                                HtmlContent = html,
                                WebSettings = { DefaultEncoding = "utf-8" }
                            }
                        }
                    };
                }
                else if (template == "Employees")
                {
                    IEnumerable<Employee> employees = null;
                    responseTask = client.GetAsync(client.BaseAddress + "/GetEmployeesToList" + "/" + garageID);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadFromJsonAsync<IList<Employee>>();
                        readTask.Wait();
                        employees = readTask.Result;
                    }
                    else
                    {
                        employees = Enumerable.Empty<Employee>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }

                    templateJson = await _reportService.GetTemplateHtmlFromApiAsync(template, 2);
                    var templates = JsonSerializer.Deserialize<List<ReportDefinition>>(templateJson, options);

                    // Make sure there's at least one template
                    razorHtml = templates?.FirstOrDefault()?.Definition
                                       ?? throw new Exception("Template not found in API response.");

                    string commonUsings = "@using System.Linq\n@using System.Collections.Generic\n";
                    string finalTemplate = commonUsings + razorHtml;

                    html = await _reportService.RenderHtmlFromTemplateAsync(finalTemplate, employees);
                    //html = await _reportService.RenderViewToStringAsync(ControllerContext, template, employees);

                    doc = new HtmlToPdfDocument()
                    {
                        GlobalSettings = {
                            PaperSize = PaperKind.A4,
                            Orientation = Orientation.Portrait,
                            DocumentTitle = $"{template}_{garageID}_{DateTime.Now}" // <-- This sets the internal title
                        },
                        Objects = {
                            new ObjectSettings()
                            {
                                HtmlContent = html,
                                WebSettings = { DefaultEncoding = "utf-8" }
                            }
                        }
                    };
                }
                else if (template == "Engineers")
                {
                    IEnumerable<Engineer> engineers = null;
                    responseTask = client.GetAsync(client.BaseAddress + "/GetEngineersToList" + "/" + garageID);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadFromJsonAsync<IList<Engineer>>();
                        readTask.Wait();
                        engineers = readTask.Result;
                        // Fetch and attach specialities for each engineer
                        foreach (var engineer in engineers)
                        {
                            var specialityResponse = await client.GetAsync(
                                client.BaseAddress + $"/GetEngineerSpecialitiesByEngineerID/{engineer.EngineerID}/{engineer.GarageID}");

                            if (specialityResponse.IsSuccessStatusCode)
                            {
                                var responseData = await specialityResponse.Content.ReadFromJsonAsync<EngineerSpecialitiesResponse>();

                                engineer.EngineerSpecialities = responseData?.Specialities
                                    .Select((spec, index) => new EngineerSpeciality
                                    {
                                        ID = index + 1, // generate ID if not provided
                                        Speciality = spec,
                                        GarageID = engineer.GarageID
                                    })
                                    .ToList();
                            }
                            else
                            {
                                engineer.EngineerSpecialities = new List<EngineerSpeciality>();
                            }
                        }

                    }
                    else
                    {
                        engineers = Enumerable.Empty<Engineer>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }

                    templateJson = await _reportService.GetTemplateHtmlFromApiAsync(template, 3);
                    var templates = JsonSerializer.Deserialize<List<ReportDefinition>>(templateJson, options);

                    // Make sure there's at least one template
                    razorHtml = templates?.FirstOrDefault()?.Definition
                                       ?? throw new Exception("Template not found in API response.");

                    string commonUsings = "@using System.Linq\n@using System.Collections.Generic\n";
                    string finalTemplate = commonUsings + razorHtml;

                    html = await _reportService.RenderHtmlFromTemplateAsync(finalTemplate, engineers);

                    //html = await _reportService.RenderViewToStringAsync(ControllerContext, template, engineers);

                    doc = new HtmlToPdfDocument()
                    {
                        GlobalSettings = {
                            PaperSize = PaperKind.A4,
                            Orientation = Orientation.Landscape,
                            DocumentTitle = $"{template}_{garageID}_{DateTime.Now}" // <-- This sets the internal title
                        },
                        Objects = {
                            new ObjectSettings()
                            {
                                HtmlContent = html,
                                WebSettings = { DefaultEncoding = "utf-8" }
                            }
                        }
                    };
                }
                else if (template == "ServiceAppointments")
                {
                    IEnumerable<ServiceAppointment> serviceAppointments = null;
                    responseTask = client.GetAsync(client.BaseAddress + "/GetServiceAppointmentsToListLiteral" + "/" + garageID + "/0/1");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadFromJsonAsync<IList<ServiceAppointment>>();
                        readTask.Wait();
                        serviceAppointments = readTask.Result;
                    }
                    else
                    {
                        serviceAppointments = Enumerable.Empty<ServiceAppointment>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }

                    templateJson = await _reportService.GetTemplateHtmlFromApiAsync(template, 4);
                    var templates = JsonSerializer.Deserialize<List<ReportDefinition>>(templateJson, options);

                    // Make sure there's at least one template
                    razorHtml = templates?.FirstOrDefault()?.Definition
                                       ?? throw new Exception("Template not found in API response.");

                    string commonUsings = "@using System.Linq\n@using System.Collections.Generic\n";
                    string finalTemplate = commonUsings + razorHtml;

                    html = await _reportService.RenderHtmlFromTemplateAsync(finalTemplate, serviceAppointments);

                    //html = await _reportService.RenderViewToStringAsync(ControllerContext, template, serviceAppointments);

                    doc = new HtmlToPdfDocument()
                    {
                        GlobalSettings = {
                            PaperSize = PaperKind.A4,
                            Orientation = Orientation.Landscape,
                            DocumentTitle = $"{template}_{garageID}_{DateTime.Now}" // <-- This sets the internal title
                        },
                        Objects = {
                            new ObjectSettings()
                            {
                                HtmlContent = html,
                                WebSettings = { DefaultEncoding = "utf-8" }
                            }
                        }
                    };
                }
            }

            var pdf = _converter.Convert(doc);
            return File(pdf, "application/pdf", $"{template}_{garageID}.pdf");
        }
    }
}