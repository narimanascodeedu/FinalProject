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
    public class TagGetAllQuery : IRequest<List<Tag>>
    {
        public class TagGetAllQueryHandler : IRequestHandler<TagGetAllQuery, List<Tag>>
        {
            private readonly MotorOilDbContext db;

            public TagGetAllQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Tag>> Handle(TagGetAllQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Tags
                .Where(bp => bp.DeletedDate == null)
                .ToListAsync(cancellationToken);

                return entity;
            }
        }
    }
}
