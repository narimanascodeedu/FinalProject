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

namespace MotorOil.Domain.Business.CategoryModule
{
    public class CategoryGetAllQuery : IRequest<List<Category>>
    {
        public class CategoryGetAllQueryHandler : IRequestHandler<CategoryGetAllQuery, List<Category>>
        {
            private readonly MotorOilDbContext db;

            public CategoryGetAllQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Category>> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Categories
                .Where(bp => bp.DeletedDate == null)
                .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
