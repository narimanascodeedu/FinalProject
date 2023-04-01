using MediatR;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotorOil.Domain.Business.TagModule
{
    public class TagCreateCommand : IRequest<Tag>
    {
        public string Text { get; set; }


        public class TagCreateCommandHandler : IRequestHandler<TagCreateCommand, Tag>
        {
            private readonly MotorOilDbContext db;

            public TagCreateCommandHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<Tag> Handle(TagCreateCommand request, CancellationToken cancellationToken)
            {
                var entity = new Tag();

                entity.Text = request.Text;

                await db.Tags.AddAsync(entity, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return entity;
            }
        }
    }
}
