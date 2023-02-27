using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;

namespace MotorOil.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ViscositiesController : Controller
    {
        private readonly MotorOilDbContext db;

        public ViscositiesController(MotorOilDbContext db)
        {
            this.db = db;
        }

        // GET: Admin/Viscosities
        [Authorize(Policy = "admin.viscosities.index")]
        public async Task<IActionResult> Index()
        {
            return View(await db.ProductViscosities.ToListAsync());
        }

        // GET: Admin/Viscosities/Details/5
        [Authorize(Policy = "admin.viscosities.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productViscosity = await db.ProductViscosities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productViscosity == null)
            {
                return NotFound();
            }

            return View(productViscosity);
        }

        // GET: Admin/Viscosities/Create
        [Authorize(Policy = "admin.viscosities.create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Viscosities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.viscosities.create")]
        public async Task<IActionResult> Create([Bind("Name,Id,CreatedDate,DeletedDate")] ProductViscosity productViscosity)
        {
            if (ModelState.IsValid)
            {
                db.Add(productViscosity);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productViscosity);
        }

        // GET: Admin/Viscosities/Edit/5
        [Authorize(Policy = "admin.viscosities.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productViscosity = await db.ProductViscosities.FindAsync(id);
            if (productViscosity == null)
            {
                return NotFound();
            }
            return View(productViscosity);
        }

        // POST: Admin/Viscosities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.viscosities.edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,CreatedDate,DeletedDate")] ProductViscosity productViscosity)
        {
            if (id != productViscosity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(productViscosity);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductViscosityExists(productViscosity.Id))
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
            return View(productViscosity);
        }

        // POST: Admin/Viscosities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.viscosities.remove")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productViscosity = await db.ProductViscosities.FindAsync(id);
            db.ProductViscosities.Remove(productViscosity);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductViscosityExists(int id)
        {
            return db.ProductViscosities.Any(e => e.Id == id);
        }
    }
}
