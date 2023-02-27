using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorOil.Application.Infrastructure
{
    public class PagedViewModel<T>
        where T : IPageable
    {
        const int maxPaginationButtonCount = 10;
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int MaxPageCount
        {
            get
            {
                double count = Math.Ceiling(this.TotalCount * 1D / this.PageSize);

                return (int)count;
            }
        }
        public IEnumerable<T> Items { get; set; }


        private bool parentCheck(T arg)
        {
            return typeof(T).GetProperty("ParentId").GetValue(arg) == null;
        }

        public PagedViewModel(IQueryable<T> query, PaginateModel model)
        {

            if (typeof(T).GetProperty("ParentId") != null)
            {
                query = query.Where(parentCheck).AsQueryable();
                this.TotalCount = query.Where(parentCheck).Count();
            }
            else
                this.TotalCount = query.Count();


            this.PageSize = model.PageSize;

            if (this.MaxPageCount < model.PageIndex)
            {
                this.PageIndex = this.MaxPageCount < 1 ? 1 : this.MaxPageCount;
            }
            else
            {
                this.PageIndex = model.PageIndex;
            }

            this.Items = query
                .Skip((this.PageIndex - 1) * this.PageSize)
                .Take(this.PageSize)
                .ToList();
        }

        


        public HtmlString GetPager(IUrlHelper urlHelper, string action, string area = "", string paginateFunction = "")
        {
            if (this.PageSize >= TotalCount)
                return HtmlString.Empty;


            StringBuilder builder = new StringBuilder();
            bool hasPaginationFunction = !string.IsNullOrWhiteSpace(paginateFunction);

            builder.Append("<ul class='li-pagination-box'>");

            if (this.PageIndex > 1)
            {
                var link = hasPaginationFunction
                    ? $"javascript:{paginateFunction}({this.PageIndex - 1},{this.PageSize})"
                    : urlHelper.Action(action, values: new
                    {
                        pageindex = this.PageIndex - 1,
                        pagesize = PageSize,
                        area
                    });

                builder.Append($@"<li><a class='Previous' href='{link}'>Əvvəlki</a></li>");

            }
            else
            {
                builder.Append("<li class='prev disabled'><a class='Previous' >Əvvəlki</a></li>");
            }

            int min = 1, max = this.MaxPageCount;

            if (this.PageIndex > (int)Math.Floor(maxPaginationButtonCount / 2D))
            {
                min = this.PageIndex - (int)Math.Floor(maxPaginationButtonCount / 2D);
            }

            max = min + maxPaginationButtonCount - 1;

            if (max > this.MaxPageCount)
            {
                max = this.MaxPageCount;
                min = max - maxPaginationButtonCount + 1;
            }

            for (int i = (min < 1 ? 1 : min); i <= max; i++)
            {
                if (i == this.PageIndex)
                {
                    builder.Append($"<li class='active'><a>{i}</a></li>");
                    continue;
                }

                var link = hasPaginationFunction
                    ? $"javascript:{paginateFunction}({i},{PageSize})"
                    : urlHelper.Action(action, values: new
                    {
                        pageindex = i,
                        pagesize = PageSize,
                        area
                    });

                builder.Append($"<li><a href='{link}'>{i}</a></li>");

            }


            if (this.PageIndex < this.MaxPageCount)
            {
                var link = hasPaginationFunction
                    ? $"javascript:{paginateFunction}({this.PageIndex + 1},{this.PageSize})"
                    : urlHelper.Action(action, values: new
                    {
                        pageindex = this.PageIndex + 1,
                        pagesize = PageSize,
                        area
                    });

                /*<li><a class='Next' href='{link}'>Next</a></li>*/

                builder.Append($@"<li><a class='Next' href='{link}'>Sonrakı</a></li>");
            }
            else
            {
                builder.Append("<li class='next disabled'><a class='Next' >Sonrakı</a></li>");
            }


            builder.Append("</ul>");

            return new HtmlString(builder.ToString());
        }
        public HtmlString GetPagerProducts(IUrlHelper urlHelper, string action, string area = "", string paginateFunction = "")
        {
            if (this.PageSize >= TotalCount)
                return HtmlString.Empty;


            StringBuilder builder = new StringBuilder();
            bool hasPaginationFunction = !string.IsNullOrWhiteSpace(paginateFunction);

            builder.Append("<ul class='pagination-box pt-xs-20 pb-xs-15'>");

            if (this.PageIndex > 1)
            {
                var link = hasPaginationFunction
                    ? $"javascript:{paginateFunction}({this.PageIndex - 1},{this.PageSize})"
                    : urlHelper.Action(action, values: new
                    {
                        pageindex = this.PageIndex - 1,
                        pagesize = PageSize,
                        area
                    });

                builder.Append($@"<li><a class='Previous' href='{link}'><i class='fa fa-chevron-left'></i> Previous</a></li>");

            }
            else
            {
                builder.Append("<li class='prev disabled'><a class='Previous' ><i class='fa fa-chevron-left'></i> Previous</a></li>");
            }

            int min = 1, max = this.MaxPageCount;

            if (this.PageIndex > (int)Math.Floor(maxPaginationButtonCount / 2D))
            {
                min = this.PageIndex - (int)Math.Floor(maxPaginationButtonCount / 2D);
            }

            max = min + maxPaginationButtonCount - 1;

            if (max > this.MaxPageCount)
            {
                max = this.MaxPageCount;
                min = max - maxPaginationButtonCount + 1;
            }

            for (int i = (min < 1 ? 1 : min); i <= max; i++)
            {
                if (i == this.PageIndex)
                {
                    builder.Append($"<li class='active'><a>{i}</a></li>");
                    continue;
                }

                var link = hasPaginationFunction
                    ? $"javascript:{paginateFunction}({i},{PageSize})"
                    : urlHelper.Action(action, values: new
                    {
                        pageindex = i,
                        pagesize = PageSize,
                        area
                    });

                builder.Append($"<li><a href='{link}'>{i}</a></li>");

            }


            if (this.PageIndex < this.MaxPageCount)
            {
                var link = hasPaginationFunction
                    ? $"javascript:{paginateFunction}({this.PageIndex + 1},{this.PageSize})"
                    : urlHelper.Action(action, values: new
                    {
                        pageindex = this.PageIndex + 1,
                        pagesize = PageSize,
                        area
                    });

                /*<li><a class='Next' href='{link}'>Next</a></li>*/

                builder.Append($@"<li><a class='Next' href='{link}'>Next <i class='fa fa-chevron-right'></i></a></li>");
            }
            else
            {
                builder.Append("<li class='next disabled'><a class='Next' >Next <i class='fa fa-chevron-right'></i></a></li>");
            }


            builder.Append("</ul>");

            return new HtmlString(builder.ToString());
        }
    }
}
