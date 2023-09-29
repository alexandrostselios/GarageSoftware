using GarageAPI.Controllers;
using GarageAPI.Data;
using GarageAPI.Models;
using GarageAPI.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Resources;
using System.Text;
using System.Web.Mvc;

namespace GarageAPI.Utilities
{
    public class TemplateGenerator
    {
        private readonly UsersController user;
        readonly Uri baseAddress = new Uri("https://localhost:7096/api");
        //readonly Uri baseAddress = new Uri(@Resources.SettingsResources.UriProduction);
        private static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:7096/api") };
        private readonly GarageAPIDbContext dbContext;

        public static string GetHTMLString()
        {
            //var responseTask = client.GetAsync(client.BaseAddress);
            //using (client)
            //{
            //    responseTask = client.GetAsync(client.BaseAddress + "/GetEngineers");
            //    responseTask.Wait();
            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsAsync<IList<Users>>();
            //        readTask.Wait();
            //        engineers = readTask.Result;
            //    }
            //}
            client.Dispose();

            var sb = new StringBuilder();
            sb.Append(@"
                <html>
                    <head></head>
	                <body>
		                <div class='header'><h1>This is the PDF FIle</h1>
		                <table align='center'>
			                <tr>
				                <th>Name</th>
				                <th>Surname</th>
				                <th>Email</th>
				                <th>Speciality</th>
			                </tr>
                        ");
            //foreach (var engineer in engineers)
            //{
            //    sb.AppendFormat(@"
            //        <tr>
            //        <td>{0}</td>
            //        <td>{1}</td>
            //        <td>{2}</td>
            //        <td>{3}</td>
            //        </tr>", engineer.Name, engineer.Surname, engineer.Email, engineer.Speciality);
            //}
            sb.Append(@"		
                    </table>
                    <h1> test test </h1>
                </body>
            </html> ");
            return sb.ToString();
        }
    }
}
