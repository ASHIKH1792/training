using FluentValidation;

namespace DManage.SystemManagement.Application.CommandHandler.NodeCommandHandler.Validator
{
    public class NodeCreateValidatorHandler : AbstractValidator<NodeCreateCommand>
    {
        public NodeCreateValidatorHandler()
        {
            RuleFor(v => v.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");
        }

    }
}
