using MediatR;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotorOil.Domain.Business.BlogPostModule
{
    public class BlogPostRemoveCommand : IRequest<BlogPost>
    {
        public int Id { get; set; }
        public class BlogPostRemoveCommandHandler : IRequestHandler<BlogPostRemoveCommand, BlogPost>
        {
            private readonly MotorOilDbContext db;

            public BlogPostRemoveCommandHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<BlogPost> Handle(BlogPostRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = db.BlogPosts.FirstOrDefault(m => m.Id == request.Id && m.DeletedDate == null);

                if (data == null)
                {
                    return null;
                }

                data.DeletedDate = DateTime.UtcNow.AddHours(4);

                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
