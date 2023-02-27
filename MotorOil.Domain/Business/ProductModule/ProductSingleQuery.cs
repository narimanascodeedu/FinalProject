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
    public class ProductSingleQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public class ProductSingleQueryHandler : IRequestHandler<ProductSingleQuery, Product>
        {
            private readonly MotorOilDbContext db;

            public ProductSingleQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }
            public async Task<Product> Handle(ProductSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Products
                    .Include(p => p.Images.Where(i => i.DeletedUserId == null))
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    .Include(p => p.ProductCatalog)
                    .ThenInclude(p => p.ProductLiter)
                    .Include(p => p.ProductCatalog)
                    .ThenInclude(p => p.ProductType)
                    .Include(p => p.ProductCatalog)
                    .ThenInclude(p => p.ProductViscosity)
                    .Include(p => p.ProductCatalog)
                    .ThenInclude(p => p.ProductApi)
                    .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);

                return data;
            }
        }
    }
}
