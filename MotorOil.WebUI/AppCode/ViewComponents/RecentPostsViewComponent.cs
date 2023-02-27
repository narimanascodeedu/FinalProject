﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorOil.Domain.Business.BlogPostModule;
using System.Threading.Tasks;

namespace MotorOil.WebUI.AppCode.ViewComponents
{
    public class RecentPostsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public RecentPostsViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new BlogPostRecentQuery() { Size = 4 };
            var posts = await mediator.Send(query);
            return View(posts);
        }
    }
}
