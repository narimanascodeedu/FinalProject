using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorOil.Domain.Business.ProductModule;
using System.Threading.Tasks;

namespace MotorOil.WebUI.AppCode.ViewComponents
{
    public class ProductEngineOilSliderViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public ProductEngineOilSliderViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new ProductEngineOilQuery() { Size = 6 };
            var products = await mediator.Send(query);
            return View(products);
        }
    }
}
