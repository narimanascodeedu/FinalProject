using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class BrandSingleQuery : IRequest<Brand>
    {
        public int Id { get; set; }

        public class BrandSingleQueryHandler : IRequestHandler<BrandSingleQuery, Brand>
        {
            private readonly MotorOilDbContext db;

            public BrandSingleQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }
            public async Task<Brand> Handle(BrandSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Brands
                    .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);

                return data;
            }
        }
    }
}
