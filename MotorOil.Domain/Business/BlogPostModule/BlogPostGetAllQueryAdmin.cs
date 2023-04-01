using MediatR;
using MotorOil.Application.Infrastructure;
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
    public class BlogPostGetAllQueryAdmin : PaginateModel, IRequest<PagedViewModel<BlogPost>>
    {
        public class BlogPostGetAllQueryAdminHandler : IRequestHandler<BlogPostGetAllQueryAdmin, PagedViewModel<BlogPost>>
        {
            private readonly MotorOilDbContext db;

            public BlogPostGetAllQueryAdminHandler(MotorOilDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<BlogPost>> Handle(BlogPostGetAllQueryAdmin request, CancellationToken cancellationToken)
            {
                //var posts = await db.BlogPosts
                //.Where(bp => bp.DeletedDate == null && bp.PublishedDate != null)
                //.ToListAsync(cancellationToken);

                int skipSize = (request.PageIndex - 1) * request.PageSize;

                var query = db.BlogPosts
                .Where(bp => bp.DeletedDate == null)
                .OrderByDescending(bp => bp.PublishedDate)
                .AsQueryable();

                var pagedModel = new PagedViewModel<BlogPost>(query, request);

                return pagedModel;
            }
        }
    }
}
