using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotorOil.Domain.Models.Entities;
using MotorOil.Domain.Models.Entities.Membership;

namespace MotorOil.Domain.Models.DataContexts
{
    public partial class MotorOilDbContext : IdentityDbContext<MotorOilUser,MotorOilRole,int,
        MotorOilUserClaim,MotorOilUserRole,MotorOilUserLogin,MotorOilRoleClaim,MotorOilUserToken>
    {
        public MotorOilDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductViscosity> ProductViscosities { get; set; }
        public DbSet<ProductLiter> ProductLiters { get; set; }
        public DbSet<ProductApi> ProductApis { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductCatalogItem> ProductCatalog { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostTagItem> BlogPostTagCloud { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MotorOilDbContext).Assembly);
        }
    }
}
