using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorOil.Domain.Business.ProductModule;
using System.Threading.Tasks;

namespace MotorOil.WebUI.AppCode.ViewComponents
{
    public class ProductSliderViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public ProductSliderViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new ProductSliderQuery() { Size = 5 };
            var products = await mediator.Send(query);
            return View(products);
        }
    }
}
