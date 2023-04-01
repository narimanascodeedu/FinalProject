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

namespace MotorOil.Domain.Business.ContactInfoModule
{
    public class ContactInfoQuery : IRequest<IEnumerable<ContactInfo>>
    {
        public class ContactInfoQueryHandler : IRequestHandler<ContactInfoQuery, IEnumerable<ContactInfo>>
        {
            private readonly MotorOilDbContext db;

            public ContactInfoQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<ContactInfo>> Handle(ContactInfoQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.ContactInfos
                    .Where(ci => ci.DeletedDate == null)
                    .ToListAsync(cancellationToken);

                return entity;
            }
        }
    }
}
