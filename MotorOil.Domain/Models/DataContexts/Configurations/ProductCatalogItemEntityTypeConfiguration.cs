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
    internal class ProductCatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<ProductCatalogItem>
    {
        public void Configure(EntityTypeBuilder<ProductCatalogItem> builder)
        {
            builder.HasKey(k => new
            {
                k.ProductId,
                k.ProductViscosityId,
                k.ProductLiterId,
                k.ProductApiId,
                k.ProductTypeId
            });
            builder.Property(t => t.Id).UseIdentityColumn();

            builder.HasIndex(t => t.Id).IsUnique();

            builder.ToTable("ProductCatalog");
        }
    }
}
