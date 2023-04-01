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
    public class TagGetSingleQuery : IRequest<Tag>
    {
        public int Id { get; set; }

        public class TagGetSingleQueryHandler : IRequestHandler<TagGetSingleQuery, Tag>
        {
            private readonly MotorOilDbContext db;

            public TagGetSingleQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<Tag> Handle(TagGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Tags
                    .FirstOrDefaultAsync(p => p.Id == request.Id);

                return data;
            }
        }
    }
}
