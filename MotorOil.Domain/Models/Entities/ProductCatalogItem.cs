using MotorOil.Application.Infrastructure;
using MotorOil.Domein.AppCode.Infrastructure;

namespace MotorOil.Domain.Models.Entities
{
    public class ProductCatalogItem : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductViscosityId { get; set; }
        public virtual ProductViscosity ProductViscosity { get; set; }
        public int ProductLiterId { get; set; }
        public virtual ProductLiter ProductLiter { get; set; }
        public int ProductApiId { get; set; }
        public virtual ProductApi ProductApi { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
