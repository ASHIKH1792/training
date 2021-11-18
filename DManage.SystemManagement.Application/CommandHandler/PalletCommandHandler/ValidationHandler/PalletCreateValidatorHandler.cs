using DManage.SystemManagement.Domain.Interface;
using FluentValidation;

namespace DManage.SystemManagement.Application.CommandHandler.PalletCommandHandler
{
    public class PalletCreateValidatorHandler : AbstractValidator<PalletCreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PalletCreateValidatorHandler(IUnitOfWork unitOfWork)
        {
            RuleFor(v => v.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

            _unitOfWork = unitOfWork;
            RuleFor(x => x.ProductTypeId).MustAsync(async (id, cancellation) =>
            {
                return await _unitOfWork.ProductTypeRepository.Any(s => s.Id == id && !s.IsDeleted);
            }).WithMessage("ProductTypeId not found").WithErrorCode("404"); ;
        }

    }
}
