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

namespace MotorOil.Domain.Business.SubscribeModule
{
    public class SubscribeGetAllQuery : IRequest<List<Subscribe>>
    {
        public class SubscribeGetAllQueryHandler : IRequestHandler<SubscribeGetAllQuery, List<Subscribe>>
        {
            private readonly MotorOilDbContext db;

            public SubscribeGetAllQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<List<Subscribe>> Handle(SubscribeGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Subscribes
                .Where(bp => bp.DeletedDate == null)
                .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
