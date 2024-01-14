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

        public IActionResult ImportCarModelsPartial()
        {
            return PartialView("_ImportCarModelsPartial");
        }

        public IActionResult ImportUsersPartial()
        {
            return PartialView("_ImportCustomersPartial");
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
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetOrder-1];
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

        public async Task<IActionResult> ImportCarModels(IFormFile file, int sheetOrder, int nameOrder, int garageIDOrder)
        {
            List<AddCarModelRequest> list = new List<AddCarModelRequest>();
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

        public async Task<IActionResult> ImportUsers(IFormFile file)
        {
            List<AddUserRequest> list = new List<AddUserRequest>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[2];
                    var rowCount = workSheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        list.Add(new AddUserRequest
                        {
                            Surname = workSheet.Cells[row, 1].Value.ToString().Trim(),
                            Name = workSheet.Cells[row, 2].Value.ToString().Trim(),
                            Email = workSheet.Cells[row, 3].Value.ToString().Trim(),
                            Password = workSheet.Cells[row, 4].Value.ToString().Trim(),
                            GarageID = Int64.Parse(workSheet.Cells[row, 5].Value.ToString()),
                            Speciality = workSheet.Cells[row, 6].Value is null || workSheet.Cells[row, 6].Value.ToString().IsEmpty() ? null : Int64.Parse(workSheet.Cells[row, 6].Value.ToString()),
                            UserType = (UserType)Int64.Parse(workSheet.Cells[row, 7].Value.ToString()),
                            EnableAccess = (EnableAccess)Int64.Parse(workSheet.Cells[row, 8].Value.ToString())
                        });
                    }
                }
            }
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddUserList/", list).Result;

            return RedirectToAction("Index", "Home");
        }
    }
}