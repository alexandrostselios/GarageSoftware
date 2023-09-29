﻿using GaragePortalNewUI.Controllers;
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

namespace GaragePortalNewUI.Utilities
{
    public class TemplateGenerator
    {
        public static string GetHTMLString(long entityType, string userID, string culture)
        {
            // Create a ResourceManager for the appropriate resource file
            ResourceManager rm = new ResourceManager("GaragePortalNewUI.Resources.SharedResource", typeof(TemplateGenerator).Assembly);

            Uri baseAddress = new Uri(@Resources.SettingsResources.Uri);
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            IEnumerable<Users> engineers = null;
            IEnumerable<UserModels> userModels = null;
            var responseTask = client.GetAsync(client.BaseAddress);
            string reportTitle = "Test PDF";
            string engineerSpecialityTag = "";
            string engineerSpecialityValue = "";
            var sb = new StringBuilder();
            using (client)
            {
                if(entityType == 2)
                {
                    responseTask = client.GetAsync(client.BaseAddress + "/GetCustomers");
                    reportTitle = "Customers";
                }
                else if (entityType == 3)
                {
                    responseTask = client.GetAsync(client.BaseAddress + "/GetEngineers");
                    reportTitle = "Engineers";
                    engineerSpecialityTag = "<th>" + rm.GetString("Engineer_Speciality", new System.Globalization.CultureInfo(culture)) + @"</th>";
                    engineerSpecialityValue = "<td>{3}</td>";
                }
                else if (entityType == 4)
                {
                    responseTask = client.GetAsync(client.BaseAddress + "/GetUserModelByUserID/"+ userID);
                    reportTitle = "Cars";
                }
                if(entityType !=4)
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
                else
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

                    int i = 1;
                    foreach (var userModel in userModels)
                    {
                        sb.AppendFormat(@"
                            <tr align='center'>"+
                                @"<td>"+ i + @")</td>
                                <td>{0}</td>
                                <td>{1}</td>
                                <td>{2}</td>
                                <td>{3}</td>
                                <td>{4}</td>
                                <td>{5}</td>
                            </tr>", userModel.ManufacturerName, userModel.ModelName, userModel.ModelYear, userModel.LicencePlate, userModel.Kilometer, userModel.VIN);
                        i++;
                    }
                    sb.Append(@"		
                                    </table>
                                </body>
                            </html> ");
                }
            }
            return sb.ToString();
        }
    }
}