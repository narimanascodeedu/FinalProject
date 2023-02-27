using MotorOil.Application.Infrastructure;
using MotorOil.Domein.AppCode.Infrastructure;

namespace MotorOil.Domain.Models.Entities
{
    public class ProductImage : BaseEntity
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
