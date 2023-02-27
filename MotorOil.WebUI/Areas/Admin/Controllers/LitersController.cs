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
    public class LitersController : Controller
    {
        private readonly MotorOilDbContext _context;

        public LitersController(MotorOilDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Liters
        [Authorize(Policy = "admin.liters.index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductLiters.ToListAsync());
        }

        // GET: Admin/Liters/Details/5
        [Authorize(Policy = "admin.liters.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productLiter = await _context.ProductLiters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productLiter == null)
            {
                return NotFound();
            }

            return View(productLiter);
        }

        // GET: Admin/Liters/Create
        [Authorize(Policy = "admin.liters.create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Liters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.liters.create")]
        public async Task<IActionResult> Create([Bind("Name,Id,CreatedDate,DeletedDate")] ProductLiter productLiter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productLiter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productLiter);
        }

        // GET: Admin/Liters/Edit/5
        [Authorize(Policy = "admin.liters.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productLiter = await _context.ProductLiters.FindAsync(id);
            if (productLiter == null)
            {
                return NotFound();
            }
            return View(productLiter);
        }

        // POST: Admin/Liters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.liters.edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,CreatedDate,DeletedDate")] ProductLiter productLiter)
        {
            if (id != productLiter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productLiter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductLiterExists(productLiter.Id))
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
            return View(productLiter);
        }

        // GET: Admin/Liters/Delete/5
        [Authorize(Policy = "admin.liters.remove")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productLiter = await _context.ProductLiters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productLiter == null)
            {
                return NotFound();
            }

            return View(productLiter);
        }

        // POST: Admin/Liters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.liters.remove")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productLiter = await _context.ProductLiters.FindAsync(id);
            _context.ProductLiters.Remove(productLiter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductLiterExists(int id)
        {
            return _context.ProductLiters.Any(e => e.Id == id);
        }
    }
}
