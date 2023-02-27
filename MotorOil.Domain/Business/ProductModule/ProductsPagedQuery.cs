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
    public class ProductsPagedQuery : PaginateModel, IRequest<PagedViewModel<Product>>
    {
        public class ProductsPagedQueryHandler : IRequestHandler<ProductsPagedQuery, PagedViewModel<Product>>
        {
            private readonly MotorOilDbContext db;

            public ProductsPagedQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<PagedViewModel<Product>> Handle(ProductsPagedQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 12)
                {
                    request.PageSize = 12;
                }
                var query = db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    .Where(m => m.DeletedDate == null)
                    .OrderByDescending(p => p.Id)
                    .AsQueryable();

                var pagedDate = new PagedViewModel<Product>(query, request);

                return pagedDate;
            }
        }
    }
}
