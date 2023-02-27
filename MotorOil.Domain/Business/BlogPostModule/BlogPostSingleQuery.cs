using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities;
using MotorOil.Domain.Models.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MotorOil.Domain.Business.BlogPostModule
{
    public class BlogPostSingleQuery : IRequest<BlogPost>
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public class BlogPostSingleQueryQueryHandler : IRequestHandler<BlogPostSingleQuery, BlogPost>
        {
            private readonly MotorOilDbContext db;

            public BlogPostSingleQueryQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }
            public async Task<BlogPost> Handle(BlogPostSingleQuery request, CancellationToken cancellationToken)
            {

                var query = db.BlogPosts
                .Include(bp => bp.CreatedByUser)
                .Include(bp => bp.Category)
                .Include(bp => bp.Comments)
                .ThenInclude(bp => bp.Children)
                .Include(bp => bp.Comments)
                .ThenInclude(c => c.CreatedByUser)
                .Include(bp => bp.TagCloud)
                .ThenInclude(bp => bp.Tag);

                if (string.IsNullOrWhiteSpace(request.Slug))
                {
                    return await query.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null);
                }

                return await query.FirstOrDefaultAsync(m => m.Slug.Equals(request.Slug) && m.DeletedDate == null);
            }
        }
    }
}
