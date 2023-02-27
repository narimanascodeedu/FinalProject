using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorOil.Application.Extensions;
using MotorOil.Domain.AppCode.Extensions;
using MotorOil.Domain.Business.BlogPostModule;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MotorOil.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IMediator mediator;
        private readonly MotorOilDbContext db;

        public BlogController(IMediator mediator,MotorOilDbContext db)
        {
            this.mediator = mediator;
            this.db = db;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(BlogPostGetAllQuery query)
        {
            var response = await mediator.Send(query);

            if(Request.IsAjaxRequest())
            {
                return PartialView("_BlogPostsBody", response);
            }

            return View(response);
        }

        [AllowAnonymous]
        [Route("/blog/{slug}")]
        public async Task<IActionResult> Details(BlogPostSingleQuery query)
        {
            var blogPost = await mediator.Send(query);

            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        [HttpPost]
        [Route("/blog/postcomment")]
        public async Task<IActionResult> PostComment(int? commentId, int postId, string comment)
        {
            if (string.IsNullOrWhiteSpace(comment))
            {
                return Json(new
                {
                    error = true,
                    message = "Şərh boş buraxıla bilməz"
                });
            }
            if (postId < 1)
            {
                return Json(new
                {
                    error = true,
                    message = "Post mövcud deyil"
                });
            }


            var post = await db.BlogPosts.FirstOrDefaultAsync(bpc => bpc.Id == postId);

            if (post == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Post mövcud deyil"
                });
            }

            var commentModel = new BlogPostComment
            {
                BlogPostId = postId,
                Text = comment,
                CreatedByUserId = User.GetCurrentUserId()
            };

            if (commentId.HasValue && await db.BlogPostComments.AnyAsync(c => c.Id == commentId))
                commentModel.ParentId = commentId;

            db.BlogPostComments.Add(commentModel);
            await db.SaveChangesAsync();

            commentModel = await db.BlogPostComments
                .Include(c => c.CreatedByUser)
                .Include(c => c.Parent)
                .FirstOrDefaultAsync(c => c.Id == commentModel.Id);

            return PartialView("_Comment",commentModel);
        }
    }
}
