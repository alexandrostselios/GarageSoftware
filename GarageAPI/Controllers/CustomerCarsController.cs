using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using GarageAPI.Models;

namespace GarageAPI.Controllers
{
    public class CustomerCarsController : Controller
    {
        private readonly GarageAPIDbContext _context;

        public CustomerCarsController(GarageAPIDbContext context)
        {
            _context = context;
        }

        // GET: CustomerCars
        public async Task<IActionResult> Index()
        {
              return View(await _context.CustomerCars.ToListAsync());
        }

        // GET: CustomerCars/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CustomerCars == null)
            {
                return NotFound();
            }

            var customerCars = await _context.CustomerCars
                .FirstOrDefaultAsync(m => m.id == id);
            if (customerCars == null)
            {
                return NotFound();
            }

            return View(customerCars);
        }

        // GET: CustomerCars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,UserID,ManufacturerDescription,ModelID,ModelDescription,ModelYear,LicencePlate,VIN,Color,Kilometer")] CustomerCars customerCars)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerCars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerCars);
        }

        // GET: CustomerCars/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CustomerCars == null)
            {
                return NotFound();
            }

            var customerCars = await _context.CustomerCars.FindAsync(id);
            if (customerCars == null)
            {
                return NotFound();
            }
            return View(customerCars);
        }

        // POST: CustomerCars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,UserID,ManufacturerDescription,ModelID,ModelDescription,ModelYear,LicencePlate,VIN,Color,Kilometer")] CustomerCars customerCars)
        {
            if (id != customerCars.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerCars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerCarsExists(customerCars.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customerCars);
        }

        // GET: CustomerCars/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CustomerCars == null)
            {
                return NotFound();
            }

            var customerCars = await _context.CustomerCars
                .FirstOrDefaultAsync(m => m.id == id);
            if (customerCars == null)
            {
                return NotFound();
            }

            return View(customerCars);
        }

        // POST: CustomerCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CustomerCars == null)
            {
                return Problem("Entity set 'GarageAPIDbContext.CustomerCars'  is null.");
            }
            var customerCars = await _context.CustomerCars.FindAsync(id);
            if (customerCars != null)
            {
                _context.CustomerCars.Remove(customerCars);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerCarsExists(long id)
        {
          return _context.CustomerCars.Any(e => e.id == id);
        }
    }
}
