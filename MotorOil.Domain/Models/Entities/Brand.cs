using MotorOil.Application.Infrastructure;
using MotorOil.Domein.AppCode.Infrastructure;
using System.Collections.Generic;

namespace MotorOil.Domain.Models.Entities
{
    public class Brand : BaseEntity,IPageable
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
