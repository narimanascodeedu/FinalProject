using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorOil.Domain.Business.TagModule;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;

namespace MotorOil.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagsController : Controller
    {
        private readonly MotorOilDbContext db;
        private readonly IMediator mediator;

        public TagsController(MotorOilDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        // GET: Admin/Tags
        [Authorize(Policy = "admin.tags.index")]
        public async Task<IActionResult> Index(TagGetAllQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Admin/Tags/Details/5
        [Authorize(Policy = "admin.tags.details")]
        public async Task<IActionResult> Details(TagGetSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Admin/Tags/Create
        [Authorize(Policy = "admin.tags.create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.tags.create")]
        public async Task<IActionResult> Create(TagCreateCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                if (response == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }

        // GET: Admin/Tags/Edit/5
        [Authorize(Policy = "admin.tags.edit")]
        public async Task<IActionResult> Edit(int? id, TagEditCommand command)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.Tags
                .FirstOrDefaultAsync(c => c.Id == id);


            if (entity == null)
            {
                return NotFound();
            }


            command.Id = entity.Id;
            command.Text = entity.Text;

            return View(command);
        }

        // POST: Admin/Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.tags.edit")]
        public async Task<IActionResult> Edit(TagEditCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                if (response == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }


        // POST: Admin/Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.tags.delete")]
        public async Task<IActionResult> DeleteConfirmed(TagRemoveCommand command)
        {
            var response = await mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TagExists(int id)
        {
            return db.Tags.Any(e => e.Id == id);
        }
    }
}
