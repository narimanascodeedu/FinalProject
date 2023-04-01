using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MotorOil.Application.Extensions;
using MotorOil.Application.Infrastructure;
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
    public class ChangeBasketQuantityCommand : IRequest<JsonResponse>
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public class ChangeBasketQuantityCommandHandler : IRequestHandler<ChangeBasketQuantityCommand, JsonResponse>
        {
            private readonly MotorOilDbContext db;
            private readonly IActionContextAccessor ctx;

            public ChangeBasketQuantityCommandHandler(MotorOilDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<JsonResponse> Handle(ChangeBasketQuantityCommand request, CancellationToken cancellationToken)
            {
                var userId = ctx.GetCurrentUserId();

                var basketItem = await db.Basket.FirstOrDefaultAsync(b => b.ProductId == request.ProductId
                                                && b.UserId == userId, cancellationToken);

                if (basketItem == null)
                {
                    basketItem = new Basket
                    {

                    UserId = userId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity < 1 ? 1 : request.Quantity
                    };

                    await db.Basket.AddAsync(basketItem, cancellationToken);
                    await db.SaveChangesAsync(cancellationToken);

                    var response = new JsonResponse
                    {
                        Error = false,
                        Message = "Sebete elave olundu"
                    };

                    var product = await db.Products.FirstOrDefaultAsync(b => b.Id == request.ProductId
                                                && b.DeletedUserId == null, cancellationToken);


                    response.Value = new
                    {
                        Id = product.Id,
                        Price = product.Price,
                        Total = (basketItem.Quantity * product.Price).ToString("0.00"),
                        Summary = await db.Basket.Where(b => b.UserId == userId).Include(b => b.Product).SumAsync(b => b.Quantity * b.Product.Price, cancellationToken),
                        Quantity = (await db.Basket.FirstOrDefaultAsync(b => b.UserId == userId && b.ProductId == product.Id)).Quantity
                    };

                    return response;
                }


                basketItem.Quantity = request.Quantity;
                await db.SaveChangesAsync(cancellationToken);

                var response2 = new JsonResponse
                {
                    Error = false,
                    Message = "Say deistirildi"
                };

                var product2 = await db.Products.FirstOrDefaultAsync(b => b.Id == request.ProductId
                                                && b.DeletedUserId == null, cancellationToken);

                response2.Value = new
                {
                    Id = product2.Id,
                    Price = product2.Price,
                    Total = basketItem.Quantity * product2.Price,
                    Summary = await db.Basket.Include(b => b.Product).SumAsync(b => b.Quantity * b.Product.Price, cancellationToken),
                    Quantity = (await db.Basket.FirstOrDefaultAsync(b => b.UserId == userId && b.ProductId == product2.Id)).Quantity

                };

                return response2;
            }
        }
    }
}
