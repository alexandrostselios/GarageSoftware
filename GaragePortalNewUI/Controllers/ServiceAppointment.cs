using GaragePortalNewUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System;
using GaragePortalNewUI.Enum;
using Microsoft.AspNetCore.Http;
using System.Linq;
using GaragePortalNewUI.ViewModels;
using GaragePortalNewUI.ViewModels.Engineer;
using System.IO;
using System.Threading.Tasks;
using System.Resources;
using System.Text.RegularExpressions;
using System.Globalization;

namespace GaragePortalNewUI.Controllers
{
    public class ServiceAppointmentController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        private readonly ResourceManager _resourceManager = new ResourceManager("GaragePortalNewUI.Resources.SharedResource", typeof(UsersController).Assembly);
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;
        readonly HttpClient client;

        public ServiceAppointmentController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("SuccessMessage") != "null")
            {
                HttpContext.Session.SetString("SuccessMessage", "null");
            }
            GetSessionProperties();
            IEnumerable<ServiceAppointmentViewModel> serviceAppointments = GetServiceAppointments(0,1);
            return View(serviceAppointments);
        }

        public ActionResult ServiceAppointments()
        {

            GetSessionProperties();
            IEnumerable<ServiceAppointmentViewModel> serviceAppointments = null;
            var responseTask = client.GetAsync(client.BaseAddress);

            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetServiceAppointmentsToListLiteral/" + ViewBag.GarageID);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ServiceAppointmentViewModel>>();
                    readTask.Wait();
                    serviceAppointments = readTask.Result;
                }
                else
                {
                    serviceAppointments = Enumerable.Empty<ServiceAppointmentViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(serviceAppointments);
        }

        public IEnumerable<ServiceAppointmentViewModel> GetServiceAppointments(long customerID, long? menu)
        {
            GetSessionProperties();
            IEnumerable<ServiceAppointmentViewModel> serviceAppointments = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetServiceAppointmentsToListLiteral/" + ViewBag.GarageID + "/" + customerID + "/" + menu);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ServiceAppointmentViewModel>>();
                    readTask.Wait();
                    serviceAppointments = readTask.Result;
                }
                else
                {
                    serviceAppointments = Enumerable.Empty<ServiceAppointmentViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return serviceAppointments;
        }

        public ActionResult GetServiceAppointmentsJSON(long customerID, long? menu, long? monthView)
        {
            GetSessionProperties();
            IEnumerable<ServiceAppointmentViewModel> serviceAppointments = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetServiceAppointmentsToListLiteral/" + ViewBag.GarageID + "/" + customerID + "/" + menu);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ServiceAppointmentViewModel>>();
                    readTask.Wait();
                    serviceAppointments = readTask.Result;
                }
                else
                {
                    serviceAppointments = Enumerable.Empty<ServiceAppointmentViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            // Map to FullCalendar event format
            var calendarEvents = serviceAppointments.Select(a => new
            {
                id = a.ID,
                customer = a.Customer,
                car = a.ManufacturerName + " " + a.ModelName + " (" + a.LicencePlate+ ")",
                kilometer = a.Kilometer,
                title = a.ServiceAppointmentComments, // or whatever title you want to show
                start = monthView == 0
                    ? a.ServiceAppointmentDate.Date.ToString("yyyy-MM-dd")
                    : a.ServiceAppointmentDate.ToString("yyyy-MM-ddTHH:mm:ss"),

                end = monthView == 0
                    ? a.ServiceAppointmentDate.Date.AddDays(1).ToString("yyyy-MM-dd")
                    : a.ServiceAppointmentDate.ToString("yyyy-MM-ddTHH:mm:ss"),

                //start = a.ServiceAppointmentDate.ToString("yyyy-MM-ddTHH:mm:ss"), // ISO 8601 format
                //end = monthView == 0 ? a.ServiceAppointmentDate.Date.AddDays(1).ToString("yyyy-MM-dd") : a.ServiceAppointmentDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                //end = a.ServiceAppointmentDate.AddMilliseconds(1).ToString("yyyy-MM-ddTHH:mm:ss"),
                allDay = monthView == 0 ? true : false,
                color = a.ServiceAppointmentStatus == ServiceAppointmentStatus.Pending ? "#42cbf5" :
                        a.ServiceAppointmentStatus == ServiceAppointmentStatus.Cancelled ? "#f0be63" :
                        "#95d479"
            });

            return new JsonResult(calendarEvents);
        }

        public IActionResult CreateServiceAppointmentPartial(long? customerID, long? customerCarID)
        {
            HttpContext.Session.SetString("CustomerID", customerID.ToString());

            GetSessionProperties();
            return PartialView("_CreateServiceAppointmentPartialView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateServiceAppointmentPartial([Bind("ID,GarageID,CustomerID,CustomerCarID,ServiceAppointmentStatus,ServiceAppointmentDate,ServiceAppointmentComments,Kilometer")] AddServiceAppointmentViewModel addServiceAppointmentViewModel)
        {
            GetSessionProperties();
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddServiceAppointment/", addServiceAppointmentViewModel).Result;

                //string successMessageInfo;
                string successMessage;
                if (response.IsSuccessStatusCode)
                {
                    //successMessageInfo = string.Format(_resourceManager.GetString("Engineer_Added_Successfully", culture), addServiceAppointmentViewModel.EngineerSurname, addServiceAppointmentViewModel.EngineerName);
                    successMessage = "Successfully Service Appointment";
                }
                else
                {
                    //successMessageInfo = string.Format(_resourceManager.GetString("Engineer_Added_Failed", culture), addServiceAppointmentViewModel.EngineerSurname, addServiceAppointmentViewModel.EngineerName);
                    successMessage = "Failed Service Appointment";
                }

                //HttpContext.Session.SetString("ServiceAppointmentCreatedInfo", successMessageInfo);
                HttpContext.Session.SetString("ServiceAppointmentCreated", successMessage);

                return RedirectToAction(nameof(ServiceAppointments));
            }
            return PartialView("_CreateCustomerPartialView", addServiceAppointmentViewModel);
        }

        public IActionResult EditServiceAppointmentPartial(long id, long customerID, long customerCarID, long garageID, long? menu)
        {
            HttpContext.Session.SetString("CustomerUserID", customerID.ToString());
            HttpContext.Session.SetString("CustomerCarID", customerCarID.ToString());

            GetSessionProperties();
            ServiceAppointmentViewModel serviceAppointment;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetServiceAppointmentByIDLiteral/" + id + "/" + garageID);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<ServiceAppointmentViewModel>();
            readTask.Wait();
            serviceAppointment = readTask.Result;
            serviceAppointment.Menu = menu;
            return PartialView("_EditServiceAppointmentPartialView", serviceAppointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditServiceAppointment(long ID, [Bind("ID", "ServiceAppointmentDate", "ServiceAppointmentComments", "ServiceAppointmentStatus", "Kilometer", "GarageID", "Menu")] UpdateServiceAppointmentViewModel editServiceAppointment)
        {
            if (ID != editServiceAppointment.ID)
            {
                return NotFound();
            }

            HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateServiceAppointment/" + editServiceAppointment.ID, editServiceAppointment).Result;
            if(editServiceAppointment.Menu == 0 || editServiceAppointment.Menu is null)
            {
                return RedirectToAction(nameof(ServiceAppointments));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateServiceAppointmentStatus(long ServiceAppointmentID,long type, long garageID)
        {
            //HttpContext.Session.SetString("CustomerUserID", null);
            //HttpContext.Session.SetString("CustomerCarID", null);
            GetSessionProperties();
            ServiceAppointmentViewModel serviceAppointment;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetServiceAppointmentByIDLiteral/" + ServiceAppointmentID + "/" + garageID);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<ServiceAppointmentViewModel>();
            readTask.Wait();
            serviceAppointment = readTask.Result;

            //ServiceAppointmentStatus status = type == 2 ? ServiceAppointmentStatus.Cancelled: ServiceAppointmentStatus.Completed;
            ServiceAppointmentStatus status = type == 1 ? ServiceAppointmentStatus.Pending : (type == 2 ? ServiceAppointmentStatus.Cancelled : ServiceAppointmentStatus.Completed);

            UpdateServiceAppointmentViewModel updateServiceAppointment = new UpdateServiceAppointmentViewModel()
            {
                ID = serviceAppointment.ID,
                GarageID = serviceAppointment.GarageID,
                Kilometer = (long)serviceAppointment.Kilometer,
                ServiceAppointmentDate = serviceAppointment.ServiceAppointmentDate,
                ServiceAppointmentComments = serviceAppointment.ServiceAppointmentComments,
                ServiceAppointmentStatus = status
            };

            HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateServiceAppointment/" + updateServiceAppointment.ID, updateServiceAppointment).Result;

            return Json(new { success = true, message = "Updated successfully." });

            //return RedirectToAction(nameof(ServiceAppointments));
        }


        private void SetSessionProperties(UserViewModel dbUser)
        {
            UserType u = (UserType)System.Enum.Parse(typeof(UserType), dbUser.UserType.ToString());
            HttpContext.Session.SetString("UserType", u.ToString());
            HttpContext.Session.SetString("ID", dbUser.ID.ToString());
            HttpContext.Session.SetString("Name", dbUser.Name);
            HttpContext.Session.SetString("Surname", dbUser.Surname);
            HttpContext.Session.SetString("SuccessMessage", "null");
            HttpContext.Session.SetString("CustomerCarID", "null");
            HttpContext.Session.SetString("CustomerUserID", "null");
            HttpContext.Session.SetString("DeleteServiceItem", "SetServiceItemsController");
        }

        private void GetSessionProperties()
        {
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.ID = HttpContext.Session.GetString("ID");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Surname = HttpContext.Session.GetString("Surname");
            ViewBag.Culture = HttpContext.Session.GetString("Culture");
            ViewBag.GarageID = HttpContext.Session.GetString("GarageID");
            ViewBag.CustomerID = HttpContext.Session.GetString("CustomerID");
            ViewBag.CustomerUserID = HttpContext.Session.GetString("CustomerUserID");
            ViewBag.CustomerCarID = HttpContext.Session.GetString("CustomerCarID");
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
            ViewBag.ServiceAppointmentCreated = HttpContext.Session.GetString("ServiceAppointmentCreated");
            //ViewBag.ServiceAppointmentCreatedInfo = HttpContext.Session.GetString("EngineerCreatedInfo");
        }

        [HttpPost]
        public ActionResult SetViewBag(string value)
        {
            HttpContext.Session.SetString("CustomerCarID", "null");
            HttpContext.Session.SetString("CustomerUserID", "null");
            HttpContext.Session.SetString("ServiceAppointmentCreated", "null");
            return new EmptyResult();
        }
    }
}