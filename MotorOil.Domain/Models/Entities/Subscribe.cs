using MotorOil.Application.Infrastructure;
using MotorOil.Domein.AppCode.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace MotorOil.Domain.Models.Entities
{
    public class Subscribe : BaseEntity
    {
        [Required(ErrorMessage = "Emailinizi daxil etməlisiniz")]
        [EmailAddress(ErrorMessage = "Email düzgün deyil")]
        public string Email { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
