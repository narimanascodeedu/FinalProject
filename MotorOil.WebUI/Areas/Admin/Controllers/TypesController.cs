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
    public class TypesController : Controller
    {
        private readonly MotorOilDbContext db;

        public TypesController(MotorOilDbContext db)
        {
            this.db = db;
        }

        // GET: Admin/Types
        [Authorize(Policy = "admin.types.index")]
        public async Task<IActionResult> Index()
        {
            return View(await db.ProductTypes.ToListAsync());
        }

        // GET: Admin/Types/Details/5
        [Authorize(Policy = "admin.types.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await db.ProductTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // GET: Admin/Types/Create
        [Authorize(Policy = "admin.types.create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Types/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.types.create")]
        public async Task<IActionResult> Create([Bind("Name,Id,CreatedDate,DeletedDate,DeletedUserId")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                db.Add(productType);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productType);
        }

        // GET: Admin/Types/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await db.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        // POST: Admin/Types/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.types.edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,CreatedDate,DeletedDate,DeletedUserId")] ProductType productType)
        {
            if (id != productType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(productType);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTypeExists(productType.Id))
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
            return View(productType);
        }

        // GET: Admin/Types/Delete/5
        [Authorize(Policy = "admin.types.remove")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await db.ProductTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // POST: Admin/Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.types.remove")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productType = await db.ProductTypes.FindAsync(id);
            db.ProductTypes.Remove(productType);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTypeExists(int id)
        {
            return db.ProductTypes.Any(e => e.Id == id);
        }
    }
}
