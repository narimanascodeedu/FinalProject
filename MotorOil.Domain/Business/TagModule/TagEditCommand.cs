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

namespace MotorOil.Domain.Business.TagModule
{
    public class TagEditCommand : IRequest<Tag>
    {
        public int Id { get; set; }

        public string Text { get; set; }


        public class TagEditCommandHandler : IRequestHandler<TagEditCommand, Tag>
        {
            private readonly MotorOilDbContext db;

            public TagEditCommandHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<Tag> Handle(TagEditCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Tags
                       .FirstOrDefaultAsync(bp => bp.Id == request.Id && bp.DeletedDate == null);
                if (entity == null)
                {
                    return null;
                }

                entity.Text = request.Text;

                await db.SaveChangesAsync(cancellationToken);

                return entity;
            }


        }
    }
}
