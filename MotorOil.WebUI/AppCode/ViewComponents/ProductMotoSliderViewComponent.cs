using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorOil.Domain.Business.ProductModule;
using System.Threading.Tasks;

namespace MotorOil.WebUI.AppCode.ViewComponents
{
    public class ProductMotoSliderViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public ProductMotoSliderViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new ProductMotoQuery() { Size = 4 };
            var products = await mediator.Send(query);
            return View(products);
        }
    }
}
