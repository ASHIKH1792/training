using DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler;
using FluentValidation;

namespace DManage.SystemManagement.Application.CommandHandler.StudentCommandHandler
{
    public class WareHouseUpdateValidatorHandler : AbstractValidator<WareHouseUpdateCommand>
    {
        public WareHouseUpdateValidatorHandler()
        {
            RuleFor(v => v.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");
        }

    }
}
