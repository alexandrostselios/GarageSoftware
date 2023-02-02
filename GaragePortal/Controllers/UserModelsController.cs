using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageManagementSoftwarePortal.Data;
using GarageManagementSoftwarePortal.Models;

namespace GarageManagementSoftwarePortal.Controllers
{
    public class UserModelsController : Controller
    {
        private readonly GarageManagementSoftwarePortalContext _context;

        public UserModelsController(GarageManagementSoftwarePortalContext context)
        {
            _context = context;
        }

        // GET: UserModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserModels.ToListAsync());
        }

        // GET: UserModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModels = await _context.UserModels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userModels == null)
            {
                return NotFound();
            }

            return View(userModels);
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
        public async Task<IActionResult> Create([Bind("ID,UserID,ModelID,ModelYear")] UserModels userModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var userModels = await _context.UserModels.FindAsync(id);
            if (userModels == null)
            {
                return NotFound();
            }
            return View(userModels);
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

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelsExists(userModels.ID))
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
            return View(userModels);
        }

        // GET: UserModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModels = await _context.UserModels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userModels == null)
            {
                return NotFound();
            }

            return View(userModels);
        }

        // POST: UserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModels = await _context.UserModels.FindAsync(id);
            _context.UserModels.Remove(userModels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelsExists(int id)
        {
            return _context.UserModels.Any(e => e.ID == id);
        }
    }
}
