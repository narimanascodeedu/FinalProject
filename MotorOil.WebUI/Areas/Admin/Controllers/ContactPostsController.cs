using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorOil.Application.Services;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;

namespace MotorOil.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactPostsController : Controller
    {
        private readonly MotorOilDbContext db;
        private readonly EmailService emailService;

        public ContactPostsController(MotorOilDbContext db, EmailService emailService)
        {
            this.db = db;
            this.emailService = emailService;
        }

        // GET: Admin/ContactPosts
        [Authorize(Policy = "admin.contactposts.index")]
        public async Task<IActionResult> Index()
        {
            return View(await db.ContactPosts.ToListAsync());
        }

        // GET: Admin/ContactPosts/Details/54
        [Authorize(Policy = "admin.contactposts.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPost = await db.ContactPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactPost == null)
            {
                return NotFound();
            }

            return View(contactPost);
        }


        [Authorize(Policy = "admin.contactposts.delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactPost = await db.ContactPosts.FindAsync(id);
            db.ContactPosts.Remove(contactPost);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "admin.contactposts.reply")]
        public async Task<IActionResult> Reply(int? id)
        {
            if (id == null)
            {
                NotFound();
            }

            var entity = await db.ContactPosts.FirstOrDefaultAsync(cp => cp.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost]
        [Authorize(Policy = "admin.contactposts.reply")]
        public async Task<IActionResult> Reply(int id, [FromForm][Bind("Name, Email, Message, Subject, Answer, EmailSubject")] ContactPost model)
        {
            var entity = db.ContactPosts.FirstOrDefault(bp => bp.Id == id && bp.AnswerDate == null);

            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    error = true,
                    message = "Xəta baş verdi"
                });
            }

            entity.AnswerDate = DateTime.UtcNow.AddHours(4);
            entity.Answer = model.Answer;
            entity.Subject = model.Subject;
            await db.SaveChangesAsync();

            await emailService.SendEmailAsync(model.Email, "Motor Oil Online Shopping", model.Answer);

            return Json(new
            {
                error = false,
                message = "Cavabınız göndərildi"
            });
        }


        private bool ContactPostExists(int id)
        {
            return db.ContactPosts.Any(e => e.Id == id);
        }
    }
}
