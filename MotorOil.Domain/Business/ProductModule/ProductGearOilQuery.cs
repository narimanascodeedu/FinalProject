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

namespace MotorOil.Domain.Business.ProductModule
{
    public class ProductGearOilQuery : IRequest<List<Product>>
    {
        public int Size { get; set; }

        public class ProductGearOilQueryHandler : IRequestHandler<ProductGearOilQuery, List<Product>>
        {
            private readonly MotorOilDbContext db;

            public ProductGearOilQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Product>> Handle(ProductGearOilQuery request, CancellationToken cancellationToken)
            {
                var products = await db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    .Where(p => p.DeletedDate == null && p.Category.ParentId == 8)
                    .OrderByDescending(p => p.CreatedDate)
                    .Take(request.Size < 3 ? 3 : request.Size)
                    .ToListAsync(cancellationToken);
                return products;
            }
        }
    }
}
