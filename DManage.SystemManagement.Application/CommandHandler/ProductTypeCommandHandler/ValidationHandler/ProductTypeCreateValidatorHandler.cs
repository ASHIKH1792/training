using FluentValidation;

namespace DManage.SystemManagement.Application.CommandHandler.ProductTypeCommandHandler
{
    public class ProductTypeCreateValidatorHandler : AbstractValidator<ProductTypeCreateCommand>
    {
        public ProductTypeCreateValidatorHandler()
        {
            RuleForEach(x => x.Name).NotEmpty().WithMessage("Name is required.")
               .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");
        }

    }
}
