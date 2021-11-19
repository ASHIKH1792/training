using FluentValidation;

namespace DManage.SystemManagement.Application.CommandHandler.DriverCommandHandler
{
    public class DriverCreateValidatorHandler : AbstractValidator<DriverCreateCommand>
    {
        public DriverCreateValidatorHandler()
        {
            RuleFor(v => v.FirstName)
               .NotEmpty().WithMessage("FirstName is required.")
               .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(v => v.LastName)
      .NotEmpty().WithMessage("LastName is required.")
      .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");


            RuleFor(v => v.MobileNumber)
      .NotEmpty().WithMessage("MobileNumber is required.")
      .MaximumLength(15).WithMessage("MobileNumber must not exceed 50 characters.");
        }

    }
}
