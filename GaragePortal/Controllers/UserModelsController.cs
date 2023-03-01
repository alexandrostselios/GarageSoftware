using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GaragePortal.Models;
using GaragePortal.Enum;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Json;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace GaragePortal.Controllers
{
    public class UserModelsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7096/api");
        HttpClient client;
        public UserModelsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            //_context = context;
            //_context = null;
        }

        // GET: UserModels
        public async Task<IActionResult> Index()
        {
            return null;
        }

        public IActionResult ViewCustomerCars(long id)
        {
            GetSessionProperties();
            string userID = string.Format(ViewBag.ID);
            if (userID == null)
            {
                return NotFound();
            }
            IEnumerable<UserModels> userCars = null;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetUserModelByUserID/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<UserModels>>();
            readTask.Wait();
            userCars = readTask.Result;

            if (userCars == null)
            {
                return NotFound();
            }
            return View(userCars);
        }

        public IActionResult ViewCarDetails(long id)
        {
            GetSessionProperties();
            if (id == null)
            {
                return NotFound();
            }
            IEnumerable<ServiceHistory> carServiceHsitory = null;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetCarServiceHistoryByUserModelsID/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<ServiceHistory>>();
            readTask.Wait();
            carServiceHsitory = readTask.Result;
            if (carServiceHsitory == null)
            {
                return NotFound();
            }
            return View(carServiceHsitory);
            //var users = null;
            //if (users == null)
            //{
            //    return NotFound();
            //}
            //return View(users);
        }

        public IActionResult EditCarDetails(long id, Colors color, int flag, IFormFile Image)
        {
            GetSessionProperties();
            IEnumerable<UserModels> userCars = null;
            var responseTask = client.GetAsync(client.BaseAddress + "/GetUserModelByCarID/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<UserModels>>();
            readTask.Wait();
            userCars = readTask.Result;
            UserModels e = userCars.FirstOrDefault(c => c.ID == id);
            CustomerCars cc = new CustomerCars
            {
                Color = e.Color,
                Kilometer = e.Kilometer,
                LicencePlate = e.LicencePlate,
                ManufacturerName = e.ManufacturerName,
                ModelName = e.ModelName,
                ModelYear = e.ModelYear,
                UserID = e.UserID,
                VIN = e.VIN,
                id = e.ID
            };
            e.Color = color;
            if (!(Image is null))
            {
                using (var stream = new MemoryStream())
                {
                    Image.CopyToAsync(stream);
                    byte[] temp = stream.ToArray();
                    e.CarImage = temp;
                }
            }
            JsonContent content = JsonContent.Create(e);

            responseTask = client.PutAsync(client.BaseAddress + "/UpdateUserModel/" + id, content);
            return View(cc);

        }

        private void GetSessionProperties()
        {
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.ID = HttpContext.Session.GetString("ID");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Surname = HttpContext.Session.GetString("Surname");
        }

        // GET: UserModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return NotFound();
            //var userModels = null;
            ////var userModels = await _context.UserModels
            ////    .FirstOrDefaultAsync(m => m.ID == id);
            //if (userModels == null)
            //{
            //    return NotFound();
            //}

            //return View(userModels);
        }

        // GET: UserModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,ModelManufacturerYear,ModelYear,LicencePlate,VIN,Color,Kilometer")] UserModelsDTO userModels)
        {
            if (ModelState.IsValid && userModels.UserID > 0)
            {
                JsonContent content = JsonContent.Create(userModels);

                HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress + "/AddUserModel/", userModels).Result;
                //return RedirectToAction(nameof(ViewCustomerCars+'1'));
                return View();
            }
            return View(userModels);
        }

        // GET: UserModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return NotFound();
            //var userModels = null //await _context.UserModels.FindAsync(id);
            //if (userModels == null)
            //{
            //    return NotFound();
            //}
            //return View(userModels);
        }

        // POST: UserModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,ModelID,ModelYear")] UserModels userModels)
        {
            if (id != userModels.ID)
            {
                return NotFound();
            }
            return NotFound();

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(userModels);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!UserModelsExists(userModels.ID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(userModels);
        }

        // GET: UserModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return NotFound();
            //var userModels = await _context.UserModels
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (userModels == null)
            //{
            //    return NotFound();
            //}

            //return View(userModels);
        }

        // POST: UserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var userModels = await _context.UserModels.FindAsync(id);
            //_context.UserModels.Remove(userModels);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelsExists(int id)
        {
            return true;
           // return _context.UserModels.Any(e => e.ID == id);
        }
    }
}
