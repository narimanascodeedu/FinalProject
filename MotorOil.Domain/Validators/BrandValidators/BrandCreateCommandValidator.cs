using MotorOil.Domain.Business.BrandModule;
using FluentValidation;

namespace MotorOil.Domain.Validators.BrandValidators
{
    public class BrandCreateCommandValidator : AbstractValidator<BrandCreateCommand>
    {
        public BrandCreateCommandValidator()
        {
            RuleFor(m=>m.Name)
                .NotEmpty()
                .WithMessage("Marka adi bosh buraxila bilmez")
                
                .MinimumLength(2)
                .WithMessage("Marka adi 2simvoldan az ola bilmez");
        }
    }
}
