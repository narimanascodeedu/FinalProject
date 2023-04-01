using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorOil.Domain.Business.ProductModule;
using System.Threading.Tasks;

namespace MotorOil.WebUI.AppCode.ViewComponents
{
    public class ProductGearOilSliderViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public ProductGearOilSliderViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new ProductGearOilQuery() { Size = 4 };
            var products = await mediator.Send(query);
            return View(products);
        }
    }
}
