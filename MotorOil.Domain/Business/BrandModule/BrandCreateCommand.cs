using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MotorOil.Application.Extensions;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotorOil.Domain.Business.BrandModule
{
    public class BrandCreateCommand : IRequest<Brand>
    {
        public string Name { get; set; }

        public class BrandCreateCommandHandler : IRequestHandler<BrandCreateCommand, Brand>
        {
            private readonly MotorOilDbContext db;
            private readonly IActionContextAccessor ctx;

            public BrandCreateCommandHandler(MotorOilDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<Brand> Handle(BrandCreateCommand request, CancellationToken cancellationToken)
            {
                if (!ctx.IsValidState())
                    return null;

                var model = new Brand();
                model.Name = request.Name;

                await db.Brands.AddAsync(model,cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return model;
            }
        }
    }
}
