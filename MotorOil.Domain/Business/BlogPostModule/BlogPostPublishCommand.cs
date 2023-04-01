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

namespace MotorOil.Domain.Business.BlogPostModule
{
    public class BlogPostPublishCommand : IRequest<BlogPost>
    {
        public int Id { get; set; }
        public class BlogPostPublishCommandHandler : IRequestHandler<BlogPostPublishCommand, BlogPost>
        {
            private readonly MotorOilDbContext db;

            public BlogPostPublishCommandHandler(MotorOilDbContext db)
            {
                this.db = db;
            }

            public async Task<BlogPost> Handle(BlogPostPublishCommand request, CancellationToken cancellationToken)
            {
                var data = await db.BlogPosts.FirstOrDefaultAsync(bp => bp.Id == request.Id && bp.PublishedDate == null);

                if (data == null)
                {
                    return null;
                }

                data.PublishedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);

                return data;
            }
        }
    }
}
