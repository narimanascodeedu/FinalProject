using MotorOil.Application.Infrastructure;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MotorOil.Domain.Business.CategoryModule
{
    public class CategoriesPagedQuery : PaginateModel, IRequest<PagedViewModel<Category>>
    {
        public override int PageSize
        {
            get
            {
                if (base.PageSize<10)
                {
                    return 10;
                }

                return base.PageSize;
            }
        }

        public class CategoriesPagedQueryHandler : IRequestHandler<CategoriesPagedQuery, PagedViewModel<Category>>
        {
            private readonly MotorOilDbContext db;

            public CategoriesPagedQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<PagedViewModel<Category>> Handle(CategoriesPagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.Categories
                    .Include(m => m.Children.Where(c => c.DeletedDate == null))
                    .OrderBy(m => m.Id)
                    .AsQueryable();

                var pagedData = new PagedViewModel<Category>(query, request);

                return pagedData;
            }
        }
    }
}
