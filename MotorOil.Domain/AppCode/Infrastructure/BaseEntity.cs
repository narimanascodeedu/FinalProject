using MotorOil.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorOil.Domein.AppCode.Infrastructure
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int? CreatedByUserId { get; set; }
        public virtual MotorOilUser CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(4);
        public DateTime? DeletedDate { get; set; }
        public int? DeletedUserId { get; set; }
        public virtual MotorOilUser DeletedUser { get; set; }
    }
}
