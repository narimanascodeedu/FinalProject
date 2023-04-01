using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotorOil.Domain.Business.CategoryModule
{
    public class CategoryEditCommand : IRequest<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
        public class CategoryEditCommandHandler : IRequestHandler<CategoryEditCommand, Category>
        {
            private readonly MotorOilDbContext db;

            public CategoryEditCommandHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<Category> Handle(CategoryEditCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Categories
                       .Include(c => c.Parent)
                       .FirstOrDefaultAsync(bp => bp.Id == request.Id && bp.DeletedDate == null);
                if (entity == null)
                {
                    return null;
                }

                entity.Name = request.Name;
                entity.ParentId = request.ParentId;


                await db.SaveChangesAsync(cancellationToken);

                return entity;
            }


        }
    }
}
