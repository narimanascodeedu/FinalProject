using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorOil.Domain.Business.ContactInfoModule;
using MotorOil.Domain.Models.DataContexts;
using System.Linq;
using System.Threading.Tasks;

namespace MotorOil.WebUI.AppCode.ViewComponents
{
    public class ContactInfosViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public ContactInfosViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new ContactInfoQuery();
            var infos = await mediator.Send(query);
            return View(infos);
        }
    }
}
