using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorOil.Application.Infrastructure;
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
    public class ProductFilterQuery : PaginateModel, IRequest<PagedViewModel<Product>>
    {
        public int[] Viscosities { get; set; }
        public int[] Apis { get; set; }
        public int[] Types { get; set; }
        public int[] Liters { get; set; }
        public int[] Brands { get; set; }
        public int[] Categories { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public class ProductFilterQueryHandler : IRequestHandler<ProductFilterQuery, PagedViewModel<Product>>
        {
            private readonly MotorOilDbContext db;

            public ProductFilterQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<Product>> Handle(ProductFilterQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 12)
                {
                    request.PageSize = 12;
                }

                var query = db.ProductCatalog.AsQueryable();


                if (request.Viscosities != null && request.Viscosities.Length > 0)
                {
                    query = query.Where(q => request.Viscosities.Contains(q.ProductViscosityId));
                }

                if (request.Apis != null && request.Apis.Length > 0)
                {
                    query = query.Where(q => request.Apis.Contains(q.ProductApiId));
                }

                if (request.Types != null && request.Types.Length > 0)
                {
                    query = query.Where(q => request.Types.Contains(q.ProductTypeId));
                }

                if (request.Liters != null && request.Liters.Length > 0)
                {
                    query = query.Where(q => request.Liters.Contains(q.ProductLiterId));
                }


                var productIds = await query.Select(q => q.ProductId).Distinct().ToArrayAsync(cancellationToken);

                var productQuery = db.Products
                    .Include(p => p.Images)
                    .Where(p => productIds.Contains(p.Id))
                    .AsQueryable();


                if (request.Brands != null && request.Brands.Length > 0)
                {
                    productQuery = productQuery.Where(q => request.Brands.Contains(q.BrandId));
                }

                if (request.Categories != null && request.Categories.Length > 0)
                {
                    productQuery = productQuery.Where(q => request.Categories.Contains(q.CategoryId));
                }

                if (request.Min > 0 && request.Min <= request.Max)
                {
                    productQuery = productQuery.Where(q => q.Price >= request.Min && q.Price <= request.Max);
                }

                productQuery = productQuery
                    .OrderByDescending(q => q.Id);

                var pagedModel = new PagedViewModel<Product>(productQuery, request);

                return pagedModel;

            }
        }
    }
}
