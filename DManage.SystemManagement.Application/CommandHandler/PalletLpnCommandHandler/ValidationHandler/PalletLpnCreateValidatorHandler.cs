using DManage.SystemManagement.Domain.Interface;
using FluentValidation;

namespace DManage.SystemManagement.Application.CommandHandler.PalletCommandHandler
{
    public class PalletLpnCreateValidatorHandler : AbstractValidator<PalletLpnCreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PalletLpnCreateValidatorHandler(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.LicensePlateNumberId).MustAsync(async (id, cancellation) =>
            {
                return await _unitOfWork.LicensePlateNumberRepository.Any(s => s.Id == id && !s.IsDeleted);
            }).WithMessage("LicensePlateNumberId not found").WithErrorCode("404");

            _unitOfWork = unitOfWork;
            RuleFor(x => x.PalletId).MustAsync(async (id, cancellation) =>
            {
                return await _unitOfWork.PalletRepository.Any(s => s.Id == id && !s.IsDeleted);
            }).WithMessage("PalletId not found").WithErrorCode("404");
        }

    }
}
