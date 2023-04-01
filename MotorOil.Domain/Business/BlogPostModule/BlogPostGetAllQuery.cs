using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class BlogPostGetAllQuery : PaginateModel, IRequest<PagedViewModel<BlogPost>>
    {
        public class BlogPostGetAllQueryHandler : IRequestHandler<BlogPostGetAllQuery, PagedViewModel<BlogPost>>
        {
            private readonly MotorOilDbContext db;

            public BlogPostGetAllQueryHandler(MotorOilDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<BlogPost>> Handle(BlogPostGetAllQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 6)
                {
                    request.PageSize = 6;
                }

                var query = db.BlogPosts
                        .Include(bp => bp.Comments)
                        .Include(bp => bp.CreatedByUser)
                        .Where(bp => bp.DeletedDate == null && bp.PublishedDate != null)
                        .OrderByDescending(bp => bp.PublishedDate)
                        .AsQueryable();
                
                        //.Skip(skipSize)
                        //.Take(request.PageSize)
                var pageModel = new PagedViewModel<BlogPost>(query,request);



                return pageModel;
            }
        }
    }
}
