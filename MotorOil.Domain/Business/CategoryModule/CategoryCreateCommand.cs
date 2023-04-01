using MediatR;
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
    public class CategoryCreateCommand : IRequest<Category>
    {
        [Required]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
        {
            private readonly MotorOilDbContext db;

            public CategoryCreateCommandHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
            {
                var entity = new Category();


                entity.Name = request.Name;
                entity.ParentId = request.ParentId;


                await db.Categories.AddAsync(entity, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return entity;
            }
        }
    }
}
