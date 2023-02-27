using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorOil.Domain.Business.CategoryModule;
using System.Threading.Tasks;

namespace MotorOil.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Policy = "admin.categories.index")]
        public async Task<IActionResult> Index(CategoriesPagedQuery query)
        {
            var response = await mediator.Send(query);

            return View(response);
        }
    }
}
