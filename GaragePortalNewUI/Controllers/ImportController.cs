using GaragePortalNewUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using GaragePortalNewUI.Enum;
using System.Web.WebPages;
using System.Globalization;
using GaragePortalNewUI.Models.EngineerSpeciality;

namespace GaragePortalNewUI.Controllers
{
    public class ImportController : Controller
    {
        readonly Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
        readonly HttpClient client = new HttpClient();

        public IActionResult ImportCarManufacturersPartial()
        {
            return PartialView("_ImportCarManufacturersPartial");
        }

        public async Task<IActionResult> ImportCarManufacturers(IFormFile file,int sheetOrder, int nameOrder, int garageIDOrder)
        {
            List<AddCarManufacturerRequest> list = new List<AddCarManufacturerRequest>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetOrder];
                    var rowCount = workSheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        list.Add(new AddCarManufacturerRequest
                        {
                            ManufacturerName = workSheet.Cells[row, nameOrder].Value.ToString().Trim(),
                            GarageID = Int64.Parse(workSheet.Cells[row, garageIDOrder].Value.ToString())
                        });
                    }
                }
            }
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddCarManufacturerList/", list).Result;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ImportCarModelsPartial()
        {
            return PartialView("_ImportCarModelsPartial");
        }

        public async Task<IActionResult> ImportCarModels(IFormFile file, int sheetOrder, int nameOrder, int garageIDOrder)
        {
            List<AddCarModelRequest> list = new List<AddCarModelRequest>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetOrder];
                    var rowCount = workSheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        list.Add(new AddCarModelRequest
                        {
                            ModelName = workSheet.Cells[row, nameOrder].Value.ToString().Trim(),
                            GarageID = Int64.Parse(workSheet.Cells[row, garageIDOrder].Value.ToString())
                        });
                    }
                }
            }
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddCarModelList/", list).Result;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ImportCustomersPartial()
        {
            return PartialView("_ImportCustomersPartial");
        }

        public async Task<IActionResult> ImportCustomers(IFormFile file, int sheetOrder, int surnameOrder, int nameOrder, int emailOrder, int passwordOrder, int enableAccessOrder, int userTypeOrder, int garageIDOrder)
        {
            List<AddCustomerRequest> list = new List<AddCustomerRequest>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetOrder-1];
                    var rowCount = workSheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        list.Add(new AddCustomerRequest
                        {
                            CustomerSurname = workSheet.Cells[row, surnameOrder].Value.ToString().Trim(),
                            CustomerName = workSheet.Cells[row, nameOrder].Value.ToString().Trim(),
                            CustomerEmail = workSheet.Cells[row, emailOrder].Value.ToString().Trim(),
                            Password = workSheet.Cells[row, passwordOrder].Value.ToString().Trim(),
                            GarageID = Int64.Parse(workSheet.Cells[row, garageIDOrder].Value.ToString()),
                            UserType = (UserType)Int64.Parse(workSheet.Cells[row, userTypeOrder].Value.ToString()),
                            EnableAccess = (EnableAccess)Int64.Parse(workSheet.Cells[row, enableAccessOrder].Value.ToString())
                        });
                    }
                }
            }
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddCustomerByList/", list).Result;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ImportEngineersPartial()
        {
            return PartialView("_ImportEngineersPartial");
        }

        public async Task<IActionResult> ImportEngineers(IFormFile file, int sheetOrder, int surnameOrder, int nameOrder, int emailOrder, int passwordOrder, int enableAccessOrder, int userTypeOrder, int garageIDOrder)
        {
            List<AddCustomerRequest> list = new List<AddCustomerRequest>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetOrder - 1];
                    var rowCount = workSheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        list.Add(new AddCustomerRequest
                        {
                            CustomerSurname = workSheet.Cells[row, surnameOrder].Value.ToString().Trim(),
                            CustomerName = workSheet.Cells[row, nameOrder].Value.ToString().Trim(),
                            CustomerEmail = workSheet.Cells[row, emailOrder].Value.ToString().Trim(),
                            Password = workSheet.Cells[row, passwordOrder].Value.ToString().Trim(),
                            GarageID = Int64.Parse(workSheet.Cells[row, garageIDOrder].Value.ToString()),
                            UserType = (UserType)Int64.Parse(workSheet.Cells[row, userTypeOrder].Value.ToString()),
                            EnableAccess = (EnableAccess)Int64.Parse(workSheet.Cells[row, enableAccessOrder].Value.ToString())
                        });
                    }
                }
            }
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddCustomerByList/", list).Result;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ImportEmployeesPartial()
        {
            return PartialView("_ImportEmployeesPartial");
        }

        public async Task<IActionResult> ImportEmployees(IFormFile file, int sheetOrder, int surnameOrder, int nameOrder, int emailOrder, int passwordOrder, int enableAccessOrder, int userTypeOrder, int garageIDOrder)
        {
            List<AddCustomerRequest> list = new List<AddCustomerRequest>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetOrder - 1];
                    var rowCount = workSheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        list.Add(new AddCustomerRequest
                        {
                            CustomerSurname = workSheet.Cells[row, surnameOrder].Value.ToString().Trim(),
                            CustomerName = workSheet.Cells[row, nameOrder].Value.ToString().Trim(),
                            CustomerEmail = workSheet.Cells[row, emailOrder].Value.ToString().Trim(),
                            Password = workSheet.Cells[row, passwordOrder].Value.ToString().Trim(),
                            GarageID = Int64.Parse(workSheet.Cells[row, garageIDOrder].Value.ToString()),
                            UserType = (UserType)Int64.Parse(workSheet.Cells[row, userTypeOrder].Value.ToString()),
                            EnableAccess = (EnableAccess)Int64.Parse(workSheet.Cells[row, enableAccessOrder].Value.ToString())
                        });
                    }
                }
            }
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddCustomerByList/", list).Result;

            return RedirectToAction("Index", "Home");
        }


        public IActionResult ImportServiceItemsPartial()
        {
            return PartialView("_ImportServiceItemsPartial");
        }

        public async Task<IActionResult> ImportServiceItems(IFormFile file, int sheetOrder, int descriptionOrder,int priceOrder, int garageIDOrder)
        {
            List<AddServiceItemRequest> list = new List<AddServiceItemRequest>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetOrder];
                    var rowCount = workSheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        decimal? price = null;

                        // Get the value as a string from the cell
                        string priceString = workSheet.Cells[row, priceOrder].Value?.ToString();

                        // Replace any commas with periods
                        priceString = priceString?.Replace(',', '.');

                        // Parse the decimal value
                        decimal parsedPrice;
                        if (!string.IsNullOrEmpty(priceString) && decimal.TryParse(priceString, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out parsedPrice))
                        {
                            price = parsedPrice;
                        }

                        list.Add(new AddServiceItemRequest
                        {
                            Description = workSheet.Cells[row, descriptionOrder].Value.ToString().Trim(),
                            Price = price,
                            GarageID = Int64.Parse(workSheet.Cells[row, garageIDOrder].Value.ToString())
                        });
                    }
                }
            }
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddServiceItemByList/", list).Result;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ImportEngineerSpecialitiesPartial()
        {
            return PartialView("_ImportEngineerSpecialitiesPartial");
        }

        public async Task<IActionResult> ImportEngineerSpecialities(IFormFile file, int sheetOrder, int engineerSpecialityOrder, int garageIDOrder)
        {
            List<EngineerSpeciality> list = new List<EngineerSpeciality>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetOrder];
                    var rowCount = workSheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        list.Add(new EngineerSpeciality
                        {
                            Speciality = workSheet.Cells[row, engineerSpecialityOrder].Value.ToString().Trim(),
                            GarageID = Int64.Parse(workSheet.Cells[row, garageIDOrder].Value.ToString())
                        });
                    }
                }
            }
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddEngineerSpecialityList/", list).Result;

            return RedirectToAction("Index", "Home");
        }
    }
}