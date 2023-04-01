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
    public class CategoryGetSingleQuery : IRequest<Category>
    {
        public int Id { get; set; }

        public class CategoryGetSingleQueryHandler : IRequestHandler<CategoryGetSingleQuery, Category>
        {
            private readonly MotorOilDbContext db;

            public CategoryGetSingleQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<Category> Handle(CategoryGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Categories
                    .Include(c => c.Parent)
                    .FirstOrDefaultAsync(p => p.Id == request.Id);

                return data;
            }
        }
    }
}
