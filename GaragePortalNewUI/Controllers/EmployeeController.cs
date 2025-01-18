using GaragePortalNewUI.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System;
using GaragePortalNewUI.Enum;
using GaragePortalNewUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System.Resources;
using GaragePortalNewUI.ViewModels.Employee;
using System.IO;
using System.Threading.Tasks;

namespace GaragePortalNewUI.Controllers
{
    public class EmployeeController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client;
        private readonly ResourceManager _resourceManager = new ResourceManager("GaragePortalNewUI.Resources.SharedResource", typeof(UsersController).Assembly);
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;

        public EmployeeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Employees(string searchBy, string searchValue, long flag)
        {
            GetSessionProperties();
            IEnumerable<EmployeeViewModel> employees = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            if (string.IsNullOrEmpty(searchValue) && flag != 0)
            {
                using (client)
                {
                    responseTask = client.GetAsync(client.BaseAddress + "/GetEmployeesToList" + "/" + ViewBag.GarageID);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<EmployeeViewModel>>();
                        readTask.Wait();
                        employees = readTask.Result;
                    }
                    else
                    {
                        employees = Enumerable.Empty<EmployeeViewModel>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            //else
            //{
            //    using (client)
            //    {
            //        if (searchBy.ToLower() == "all")
            //        {
            //            responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/0/2/" + searchValue + '/' + ViewBag.GarageID);
            //        }
            //        else if (searchBy.ToLower() == "name")
            //        {
            //            responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/1/2/" + searchValue + '/' + ViewBag.GarageID);
            //        }
            //        else if (searchBy.ToLower() == "surname")
            //        {
            //            responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/2/2/" + searchValue + '/' + ViewBag.GarageID);
            //        }
            //        else if (searchBy.ToLower() == "email")
            //        {
            //            responseTask = client.GetAsync(client.BaseAddress + "/GetUsersByValue/3/2/" + searchValue + '/' + ViewBag.GarageID);
            //        }
            //        responseTask.Wait();
            //        var result = responseTask.Result;
            //        if (result.IsSuccessStatusCode)
            //        {
            //            var readTask = result.Content.ReadAsAsync<IList<CustomerViewModel>>();
            //            readTask.Wait();
            //            customers = readTask.Result;
            //        }
            //        else
            //        {
            //            customers = Enumerable.Empty<CustomerViewModel>();
            //            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //        }
            //    }
            //}
            return View(employees);
        }

        public IEnumerable<EmployeeViewModel> GetEmployeesList()
        {
            IEnumerable<EmployeeViewModel> employeesList = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            using (client)
            {
                responseTask = client.GetAsync(client.BaseAddress + "/GetEmployeesToList" + "/1"); /*+ ViewBag.GarageID);*/
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<EmployeeViewModel>>();
                    readTask.Wait();
                    employeesList = readTask.Result;
                }
                else
                {
                    employeesList = Enumerable.Empty<EmployeeViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return employeesList;
        }

        public IActionResult CreateEmployeePartial()
        {
            GetSessionProperties();
            return PartialView("_CreateEmployeePartialView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEmployeePartial([Bind("ID,EmployeeName,EmployeeSurname,EmployeeEmail,Age,EmployeePassword,EmployeePassword,EmployeePhoto,EmployeeMobilePhone,EmployeeHomePhone,GarageID,EnableAccess,EmployeeComment")] EmployeeViewModel createUser, IFormFile Image)
        {
            GetSessionProperties();
            if (!(createUser.EmployeeEmail is null) && ModelState.IsValid)
            {
                createUser.UserType = UserType.Employee;
                createUser.CreationDate = DateTime.Now;
                //createUser.EnableAccess = EnableAccess.Enable;
                createUser.EmployeePhoto = null;
                if (Image != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        Image.CopyToAsync(stream);
                        byte[] temp = stream.ToArray();
                        createUser.EmployeePhoto = temp;
                    }
                }
                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddEmployee/", createUser).Result;

                string successMessageInfo;
                string successMessage;
                if (response.IsSuccessStatusCode)
                {
                    successMessageInfo = string.Format(_resourceManager.GetString("Employee_Added_Successfully", culture), createUser.EmployeeSurname, createUser.EmployeeName);
                    successMessage = "Successfully";
                }
                else
                {
                    successMessageInfo = string.Format(_resourceManager.GetString("Employee_Added_Failed", culture), createUser.EmployeeSurname, createUser.EmployeeName);
                    successMessage = "Failed";
                }

                HttpContext.Session.SetString("EmployeeCreatedInfo", successMessageInfo);
                HttpContext.Session.SetString("EmployeeCreated", successMessage);

                return RedirectToAction(nameof(Employees));
            }
            return PartialView("_CreateEmployeePartialView", createUser);

            //return RedirectToAction(nameof(Customers));
            //return RedirectToAction(nameof(Index));
            // return View(createUser);
        }

        public IActionResult EditEmployeePartial(long id, long garageID)
        {
            GetSessionProperties();
            EmployeeViewModel editEmployee;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetEmployeeByID/" + id + "/" + garageID);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<EmployeeViewModel>();
            readTask.Wait();
            editEmployee = readTask.Result;
            return PartialView("_EditEmployeePartialView", editEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployee(long employeeID, [Bind("EmployeeID,EmployeeName,EmployeeSurname,EmployeeEmail,EmployeePhoto,CreationDate,EmployeeMobilePhone,EmployeeHomePhone,ModifiedDate,LastLoginDate,EnableAccess,GarageID,EmployeeComment")] EmployeeViewModel editEmployee, IFormFile Image)
        {
            if (employeeID != editEmployee.EmployeeID)
            {
                return NotFound();
            }

            //if (!(editCustomer.CustomerPhoto is null))
            //{
            //    using (var stream = new MemoryStream())
            //    {
            //        Image.CopyToAsync(stream);
            //        byte[] temp = stream.ToArray();
            //        editCustomer.CustomerPhoto = temp;
            //    }
            //}

            if (!(Image is null))
            {
                using (var stream = new MemoryStream())
                {
                    Image.CopyToAsync(stream);
                    byte[] temp = stream.ToArray();
                    editEmployee.EmployeePhoto = temp;
                }
            }

            editEmployee.ModifiedDate = DateTime.Now;
            HttpResponseMessage response = client.PutAsJsonAsync(client.BaseAddress + "/UpdateEmployee/" + editEmployee.EmployeeID, editEmployee).Result;

            return RedirectToAction(nameof(Employees));
        }

        private void SetSessionProperties(UserViewModel dbUser)
        {
            UserType u = (UserType)System.Enum.Parse(typeof(UserType), dbUser.UserType.ToString());
            HttpContext.Session.SetString("UserType", u.ToString());
            HttpContext.Session.SetString("ID", dbUser.ID.ToString());
            HttpContext.Session.SetString("Name", dbUser.Name);
            HttpContext.Session.SetString("Surname", dbUser.Surname);
            HttpContext.Session.SetString("SuccessMessage", "null");
            HttpContext.Session.SetString("GarageID", dbUser.GarageID.ToString());
            HttpContext.Session.SetString("DeleteServiceItem", "UsersController");
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
            ViewBag.GarageID = HttpContext.Session.GetString("GarageID");
            ViewBag.CustomerCreated = HttpContext.Session.GetString("CustomerCreated");
            ViewBag.CustomerCreatedInfo = HttpContext.Session.GetString("CustomerCreatedInfo");
            ViewBag.EngineerCreated = HttpContext.Session.GetString("EngineerCreated");
            ViewBag.EngineerCreatedInfo = HttpContext.Session.GetString("EngineerCreatedInfo");
            ViewBag.EmployeeCreated = HttpContext.Session.GetString("EmployeeCreated");
            ViewBag.EmployeeCreatedInfo = HttpContext.Session.GetString("EmployeeCreatedInfo");
        }

        [HttpPost]
        public ActionResult SetViewBag(string value)
        {
            HttpContext.Session.SetString("SuccessMessage", "null");
            HttpContext.Session.SetString("CustomerCreated", "null");
            HttpContext.Session.SetString("CustomerCreatedInfo", "null");
            HttpContext.Session.SetString("EngineerCreated", "null");
            HttpContext.Session.SetString("EngineerCreatedInfo", "null");
            return new EmptyResult();
        }
    }
}