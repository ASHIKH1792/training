using FluentValidation;

namespace DManage.SystemManagement.Application.CommandHandler.TruckCommandHandler
{
    public class TruckCreateValidatorHandler : AbstractValidator<TruckCreateCommand>
    {
        public TruckCreateValidatorHandler()
        {
            RuleFor(v => v.RegistrationNumber)
               .NotEmpty().WithMessage("Registration Number is required.")
               .MaximumLength(20).WithMessage("Registration Number must not exceed 20 characters.");

            RuleFor(v => v.Model)
      .NotEmpty().WithMessage("Model Number is required.")
      .MaximumLength(50).WithMessage("Model Number must not exceed 20 characters.");
        }

    }
}
