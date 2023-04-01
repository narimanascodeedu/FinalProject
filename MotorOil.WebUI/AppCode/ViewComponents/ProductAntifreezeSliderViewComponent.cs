using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorOil.Domain.Business.ProductModule;
using System.Threading.Tasks;

namespace MotorOil.WebUI.AppCode.ViewComponents
{
    public class ProductAntifreezeSliderViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public ProductAntifreezeSliderViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new ProductAntifreezeQuery() { Size = 4 };
            var products = await mediator.Send(query);
            return View(products);
        }
    }
}
