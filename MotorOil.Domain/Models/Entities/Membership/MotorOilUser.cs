using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MotorOil.Domain.Models.Entities.Membership
{
    public class MotorOilUser : IdentityUser<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
