﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MotorOil.Application.Extensions;
using MotorOil.Domain.Business.BlogPostModule;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;

namespace MotorOil.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly MotorOilDbContext db;
        private readonly IHostEnvironment env;
        private readonly IMediator mediator;

        public BlogPostsController(MotorOilDbContext db, IHostEnvironment env,IMediator mediator)
        {
            this.db = db;
            this.env = env;
            this.mediator = mediator;
        }

        // GET: Admin/BlogPosts
        [Authorize(Policy = "admin.blogposts.index")]
        public async Task<IActionResult> Index()
        {
            var data = await db.BlogPosts
                .Where(bp => bp.DeletedDate == null)
                .ToListAsync();
            return View(data);
        }

        // GET: Admin/BlogPosts/Details/5
        [Authorize(Policy = "admin.blogposts.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await db.BlogPosts
                .Include(bp => bp.Category)
                .Include(bp => bp.TagCloud)
                .ThenInclude(bp => bp.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // GET: Admin/BlogPosts/Create
        [Authorize(Policy = "admin.blogposts.create")]
        public IActionResult Create()
        {

            ViewBag.CategoryId = new SelectList(db.Categories.Where(t => t.DeletedDate == null).ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(db.Tags.Where(t => t.DeletedDate == null).ToList(), "Id", "Text");

            return View();
        }

        // POST: Admin/BlogPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.blogposts.create")]
        public async Task<IActionResult> Create(BlogPostCreateCommand command)
        {
            if (command.Image == null)
            {
                ModelState.AddModelError("ImagePath","Sekil gonderilmelidi");
            }
            if (ModelState.IsValid)
            {

                var response = await mediator.Send(command);

                if (response.Error == false)
                {
                    return RedirectToAction(nameof(Index));

                }
            }

            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Name",command.CategoryId);
            ViewBag.Tags = new SelectList(db.Tags.Where(t => t.DeletedDate == null).ToList(), "Id", "Text");

            return View(command);
        }

        // GET: Admin/BlogPosts/Edit/5
        [Authorize(Policy = "admin.blogposts.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await db.BlogPosts
                .Include(bp => bp.TagCloud)
                .FirstOrDefaultAsync(bp => bp.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Name", blogPost.CategoryId);
            ViewBag.Tags = new SelectList(db.Tags.Where(t => t.DeletedDate == null).ToList(), "Id", "Text");

            var editCommand = new BlogPostEditCommand();
            editCommand.Id = blogPost.Id;
            editCommand.Title = blogPost.Title;
            editCommand.Body = blogPost.Body;
            editCommand.ImagePath = blogPost.ImagePath;
            editCommand.CategoryId = blogPost.CategoryId;
            editCommand.Id = blogPost.Id;
            editCommand.TagIds = blogPost.TagCloud.Select(tc => tc.TagId).ToArray();

            return View(editCommand);
        }

        // POST: Admin/BlogPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.blogposts.edit")]
        public async Task<IActionResult> Edit(int id, BlogPostEditCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            var response = await mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            if (response.Error == false)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Name", command.CategoryId);
            ViewBag.Tags = new SelectList(db.Tags.Where(t => t.DeletedDate == null).ToList(), "Id", "Text");

            return View(command);
        }

        // POST: Admin/BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.blogposts.remove")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await db.BlogPosts
                    .FirstOrDefaultAsync(bp => bp.Id == id && bp.DeletedDate == null);

            if (entity == null)
            {
                return NotFound();
            }

            entity.DeletedDate = DateTime.UtcNow.AddHours(4);

            env.ArchiveImage(entity.ImagePath);

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogPostExists(int id)
        {
            return db.BlogPosts.Any(e => e.Id == id);
        }
    }
}
