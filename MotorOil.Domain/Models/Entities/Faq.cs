using MotorOil.Application.Infrastructure;
using MotorOil.Domein.AppCode.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace MotorOil.Domain.Models.Entities
{
    public class Faq : BaseEntity
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}
