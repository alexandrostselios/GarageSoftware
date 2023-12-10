using GaragePortalNewUI.Controllers;
using GaragePortalNewUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Globalization;
using System.Resources;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using System.Web.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic;

namespace GaragePortalNewUI.Utilities
{
    public class TemplateGenerator
    {
        public static string GetHTMLString(long entityType, string userID, string culture, long? serviceHistoryID)
        {
            // Create a ResourceManager for the appropriate resource file
            ResourceManager rm = new ResourceManager("GaragePortalNewUI.Resources.SharedResource", typeof(TemplateGenerator).Assembly);

            Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            IEnumerable<Users> engineers = null;
            IEnumerable<UserModels> userModels = null;
            IEnumerable<ServiceHistoryWithItemsDTO> serviceHistoryDTO = null;
            //IEnumerable<ServiceHistoryWithItemsDTO> serviceHistoryItems = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            var responseTaskServiceItems = client.GetAsync(client.BaseAddress);
            string reportTitle = "Test PDF";
            string engineerSpecialityTag = "";
            string engineerSpecialityValue = "";
            var sb = new StringBuilder();
            using (client)
            {
                if(entityType == 2)
                {
                    responseTask = client.GetAsync(client.BaseAddress + "/GetCustomers/1");
                    reportTitle = "Customers";
                }
                else if (entityType == 3)
                {
                    responseTask = client.GetAsync(client.BaseAddress + "/GetEngineers/1");
                    reportTitle = "Engineers";
                    engineerSpecialityTag = "<th>" + rm.GetString("Engineer_Speciality", new System.Globalization.CultureInfo(culture)) + @"</th>";
                    engineerSpecialityValue = "<td>{3}</td>";
                }
                else if (entityType == 4)
                {
                    responseTask = client.GetAsync(client.BaseAddress + "/GetUserModelByUserID/"+ userID);
                    reportTitle = "Cars";
                }else if(entityType == 5)
                {
                    responseTask = client.GetAsync(client.BaseAddress + "/GetCarServiceHistoryByServiceHistoryID/" + serviceHistoryID);
                    //responseTaskServiceItems = client.GetAsync(client.BaseAddress + "/GetServiceHistoryItemsByServiceHistoryID/" + serviceHistoryID + "/1");
                    reportTitle = "Service History";
                }
                if(entityType == 2 || entityType == 3)
                {
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Users>>();
                        readTask.Wait();
                        engineers = readTask.Result;
                    }
                    sb.Append(@"
                        <html>
                            <head>    
                                <style>
                                    table {
                                        width: 100%;
                                        border-collapse: collapse;
                                    }
                                    table, th, td {
                                        border: 1px solid #ddd;
                                    }
                                    th, td {
                                        padding: 8px;
                                        text-align: center;
                                    }
                                    th {
                                        background-color: #f2f2f2;
                                    }
                                </style>
                            </head>
	                        <body>
		                        <div class='header'><h1><center>List of all " + reportTitle + @"</center></h1>
		                        <table align='center' style='width:100%'>
			                        <tr>
				                        <th>" + rm.GetString("Name", new System.Globalization.CultureInfo(culture)) + @"</th>
				                        <th>" + rm.GetString("Surname", new System.Globalization.CultureInfo(culture)) + @"</th>
				                        <th>Email</th>"
                                        + engineerSpecialityTag +
                                  @"</tr>");

                            foreach (var engineer in engineers)
                            {
                                sb.AppendFormat(@"
                                    <tr align='center'>
                                        <td>{0}</td>
                                        <td>{1}</td>
                                        <td>{2}</td>"
                                                + engineerSpecialityValue +
                                         @"</tr>", engineer.Name, engineer.Surname, engineer.Email, entityType == 3 ? engineer.EngineerSpeciality : "");
                            }
                            sb.Append(@"		
                                    </table>
                                </body>
                            </html> ");
                }
                else if(entityType ==4)
                {
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<UserModels>>();
                        readTask.Wait();
                        userModels = readTask.Result;
                    }

                    sb.Append(@"
                        <html>
                            <head>
                                <style>
                                    table {
                                        width: 100%;
                                        border-collapse: collapse;
                                    }
                                    table, th, td {
                                        border: 1px solid #ddd;
                                    }
                                    th, td {
                                        padding: 8px;
                                        text-align: center;
                                    }
                                    th {
                                        background-color: #f2f2f2;
                                    }
                                </style>
                            </head>
	                        <body>
		                        <div class='header'><h1><center>List of all " + reportTitle + @"</center></h1>
		                        <table align='center' style='width:100%'>
			                        <tr>
                                        <th>A/A</th>
				                        <th>" + rm.GetString("Model_Manufacturer", new System.Globalization.CultureInfo(culture)) + @"</th>
				                        <th>"+ rm.GetString("Model", new System.Globalization.CultureInfo(culture)) + @"</th>
				                        <th>" + rm.GetString("Model_Year", new System.Globalization.CultureInfo(culture)) + @"</th>
                                        <th>" + rm.GetString("Licence_Plate", new System.Globalization.CultureInfo(culture)) + @"</th>
                                        <th>"+ rm.GetString("Kilometer", new System.Globalization.CultureInfo(culture)) + @"</th>
                                        <th>VIN</th>
                                    </tr>");

                    int k = 1;
                    foreach (var userModel in userModels)
                    {
                        sb.AppendFormat(@"
                            <tr align='center'>"+
                                @"<td>"+ k + @")</td>
                                <td>{0}</td>
                                <td>{1}</td>
                                <td>{2}</td>
                                <td>{3}</td>
                                <td>{4}</td>
                                <td>{5}</td>
                            </tr>", userModel.ManufacturerName, userModel.ModelName, userModel.ModelYear, userModel.LicencePlate, userModel.Kilometer, userModel.VIN);
                        k++;
                    }
                    sb.Append(@"		
                                    </table>
                                </body>
                            </html> ");
                }
                else if (entityType == 5)
                {
                    responseTask.Wait();
                    var result = responseTask.Result;

                    responseTaskServiceItems.Wait();
                    var resultServiceItems = responseTaskServiceItems.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<ServiceHistoryWithItemsDTO>>();
                        readTask.Wait();
                        serviceHistoryDTO = readTask.Result;
                    }

                    sb.Append(@"<html>
	                        <head>
		                        <style>
			                        table {
				                        width: 100%;
				                        border-collapse: collapse;
			                        }
			                        table, th, td {
				                        border: 1px solid #ddd;
			                        }
			                        th, td {
				                        padding: 8px;
				                        text-align: center;
			                        }
			                        th {
				                        background-color: #f2f2f2;
			                        }
		                        </style>
	                        </head>
	                        <body>
		                        <div class='header'><h1><center>" + reportTitle + @"</center></h1>");

                    sb.Append(@"<table align='center' style='width:100%'>
			                            <tr>
                                            <th>" + rm.GetString("Model_Manufacturer", new System.Globalization.CultureInfo(culture)) + @"</th>
                                            <th>" + rm.GetString("Model", new System.Globalization.CultureInfo(culture)) + @"</th>
                                            <th>" + rm.GetString("Model_Year", new System.Globalization.CultureInfo(culture)) + @"</th>
                                            <th>" + rm.GetString("Engine_Type", new System.Globalization.CultureInfo(culture)) + @"</th>
                                            <th>" + rm.GetString("Licence_Plate", new System.Globalization.CultureInfo(culture)) + @"</th>
                                            <th>VIN</th>
                                        </tr>");
                    sb.AppendFormat(@"
                            <tr align='center'>" +
                               @"
                                <td>{0}</td>
                                <td>{1}</td>
                                <td>{2}</td>
                                <td>{3}</td>
                                <td>{4}</td>
                                <td>{5}</td>
                            </tr>", serviceHistoryDTO.ElementAt(0).ManufacturerName, serviceHistoryDTO.ElementAt(0).ModelName, serviceHistoryDTO.ElementAt(0).ModelYear, serviceHistoryDTO.ElementAt(0).EngineType, serviceHistoryDTO.ElementAt(0).LicencePlate, serviceHistoryDTO.ElementAt(0).VIN);
                    sb.Append(@"</table><br><br>");

                    sb.AppendFormat(@"
                                <table align='center' style='width:100%'>
			                        <tr>
				                        <th>" + rm.GetString("Service_Date", new System.Globalization.CultureInfo(culture)) + @"</th>
				                        <th>" + rm.GetString("Service_Engineer", new System.Globalization.CultureInfo(culture)) + @"</th>
				                        <th>" + rm.GetString("Service_StartPrice", new System.Globalization.CultureInfo(culture)) + @"</th>
                                        <th>" + rm.GetString("Discount_Price", new System.Globalization.CultureInfo(culture)) + @"</th>
				                        <th>" + rm.GetString("Service_FinalPrice", new System.Globalization.CultureInfo(culture)) + @"</th>
				                        <th>" + rm.GetString("Service_Kilometer", new System.Globalization.CultureInfo(culture)) + @"</th>
                                    </tr>
                    ");
                    DateTime dt;
                    DateTime.TryParse(serviceHistoryDTO.ElementAt(0).ServiceDate.ToString(), out dt);
                    sb.AppendFormat(@"
                            <tr align='center'>" +
                               @"
                                <td>{0}</td>
                                <td>{1}</td>
                                <td>{2} €</td>
                                <td>{3}</td>
                                <td>{4} €</td>
                                <td>{5}</td>
                            </tr>", dt.ToString("dd/MM/yyyy"), serviceHistoryDTO.ElementAt(0).Surname + ' ' + serviceHistoryDTO.ElementAt(0).Name, serviceHistoryDTO.ElementAt(0).StartPrice,
                             "--", serviceHistoryDTO.ElementAt(0).FinalPrice, serviceHistoryDTO.ElementAt(0).ServiceKilometer
                            );

                    sb.Append(@"</table><br><br>");
                    sb.Append(@"<table align='center' style='width:100%'>
			                        <tr>
                                        <th>A/A</th>
                                        <th>" + rm.GetString("Service_Items", new System.Globalization.CultureInfo(culture)) + @"</th>
                                        <th>" + rm.GetString("Price", new System.Globalization.CultureInfo(culture)) + @"</th>
                                    </tr>");
                    int i = 1;
                    double totalServiceItemPrice = 0;
                    foreach (var serviceItem in serviceHistoryDTO)
                    {
                        sb.AppendFormat(@"
                                <tr align='center'>" +
                                @"<td>" + i + @")</td>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                </tr>", serviceItem.ServiceItemDescription, serviceItem.ServiceItemPrice > 0 ? serviceItem.ServiceItemPrice + " €" : "--");
                        i++;
                        totalServiceItemPrice += Convert.ToDouble(serviceItem.ServiceItemPrice);
                    }

                    sb.AppendFormat(@"<br>
                    <tr style='font-weight: bold; background-color: white'><td colspan='2'; style='text-align: right'>" + rm.GetString("Total", new System.Globalization.CultureInfo(culture)) + @": </td><td> {0} € </td></tr>
                    </table><br><br>", totalServiceItemPrice);


                    sb.AppendFormat(@"<b>" + rm.GetString("Comments", new System.Globalization.CultureInfo(culture)) + @":</b> {0}", serviceHistoryDTO.ElementAt(0).Description);
                    sb.Append(@"</body>
                                </html>");
                }
            }
            return sb.ToString();
        }
    }
}