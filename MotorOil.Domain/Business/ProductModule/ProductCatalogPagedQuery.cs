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
    public class ProductCatalogPagedQuery : PaginateModel, IRequest<PagedViewModel<ProductCatalogItem>>
    {
        public class ProductCatalogPagedQueryHandler : IRequestHandler<ProductCatalogPagedQuery, PagedViewModel<ProductCatalogItem>>
        {
            private readonly MotorOilDbContext db;

            public ProductCatalogPagedQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<PagedViewModel<ProductCatalogItem>> Handle(ProductCatalogPagedQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 12)
                {
                    request.PageSize = 12;
                }
                var query = db.ProductCatalog
                    .Include(pc => pc.Product)
                    .Include(pc => pc.ProductApi)
                    .Include(pc => pc.ProductLiter)
                    .Include(pc => pc.ProductType)
                    .Include(pc => pc.ProductViscosity)
                    .Where(pc => pc.DeletedDate == null)
                    .OrderByDescending(pc => pc.Id)
                    .AsQueryable();

                var pagedDate = new PagedViewModel<ProductCatalogItem>(query, request);

                return pagedDate;

            }
        }
    }
}
