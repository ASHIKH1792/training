using FluentValidation;

namespace DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler.Validator
{
    public class WareHouseCreateValidatorHandler : AbstractValidator<WareHouseCreateCommand>
    {
        public WareHouseCreateValidatorHandler()
        {
            RuleFor(v => v.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");
        }

    }
}
