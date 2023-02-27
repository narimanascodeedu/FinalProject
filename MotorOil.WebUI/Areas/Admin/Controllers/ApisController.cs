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
    public class ApisController : Controller
    {
        private readonly MotorOilDbContext db;

        public ApisController(MotorOilDbContext db)
        {
            this.db = db;
        }

        [Authorize(Policy = "admin.apis.index")]
        public async Task<IActionResult> Index()
        {
            return View(await db.ProductApis.ToListAsync());
        }

        [Authorize(Policy = "admin.apis.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productApi = await db.ProductApis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productApi == null)
            {
                return NotFound();
            }

            return View(productApi);
        }

        [Authorize(Policy = "admin.apis.create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Apis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.apis.create")]
        public async Task<IActionResult> Create([Bind("Name,Id,CreatedDate,DeletedDate")] ProductApi productApi)
        {
            if (ModelState.IsValid)
            {
                db.Add(productApi);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productApi);
        }

        [Authorize(Policy = "admin.apis.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productApi = await db.ProductApis.FindAsync(id);
            if (productApi == null)
            {
                return NotFound();
            }
            return View(productApi);
        }

        // POST: Admin/Apis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.apis.edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,CreatedDate,DeletedDate")] ProductApi productApi)
        {
            if (id != productApi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(productApi);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductApiExists(productApi.Id))
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
            return View(productApi);
        }

        // GET: Admin/Apis/Delete/5
        [Authorize(Policy = "admin.apis.remove")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productApi = await db.ProductApis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productApi == null)
            {
                return NotFound();
            }

            return View(productApi);
        }

        // POST: Admin/Apis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.apis.remove")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productApi = await db.ProductApis.FindAsync(id);
            db.ProductApis.Remove(productApi);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductApiExists(int id)
        {
            return db.ProductApis.Any(e => e.Id == id);
        }
    }
}
