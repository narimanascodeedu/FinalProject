using MotorOil.Application.Infrastructure;
using MotorOil.Domein.AppCode.Infrastructure;
using System.Collections.Generic;

namespace MotorOil.Domain.Models.Entities
{
    public class ProductApi : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<ProductCatalogItem> ProductCatalog { get; set; }

    }
}
