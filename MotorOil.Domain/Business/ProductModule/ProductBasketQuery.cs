using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MotorOil.Domain.AppCode.Extensions;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotorOil.Domain.Business.ProductModule
{
    public class ProductBasketQuery : IRequest<IEnumerable<Basket>>
    {

        public class ProductBasketQueryHandler : IRequestHandler<ProductBasketQuery, IEnumerable<Basket>>
        {
            private readonly MotorOilDbContext db;
            private readonly IActionContextAccessor ctx;

            public ProductBasketQueryHandler(MotorOilDbContext db,IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<IEnumerable<Basket>> Handle(ProductBasketQuery request, CancellationToken cancellationToken)
            {
                if (!ctx.ActionContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    return Enumerable.Empty<Basket>();
                }

                var userId = ctx.GetCurrentUserId();

                var data = await db.Basket
                    .Include(b => b.Product)
                    .ThenInclude(p => p.Images.Where(i => i.IsMain && i.DeletedUserId == null))

                    .Where(b => b.UserId == userId)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
