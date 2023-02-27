using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorOil.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorOil.Domain.Models.DataContexts.Configurations
{
    public class BlogPostTagItemEntityTypeConfiguration : IEntityTypeConfiguration<BlogPostTagItem>
    {
        public void Configure(EntityTypeBuilder<BlogPostTagItem> builder)
        {
            builder.HasKey(k => new {k.BlogPostId, k.TagId});
            builder.Property(p => p.Id).UseIdentityColumn();

            builder.ToTable("BlogPostTagCloud");
        }
    }
}
