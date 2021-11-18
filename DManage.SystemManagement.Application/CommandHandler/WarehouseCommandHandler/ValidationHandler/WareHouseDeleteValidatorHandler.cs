using DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler;
using DManage.SystemManagement.Domain.Interface;
using FluentValidation;

namespace DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler
{
    public class WareHouseDeleteValidatorHandler : AbstractValidator<WareHouseDeleteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public WareHouseDeleteValidatorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
            {
                return await _unitOfWork.WareHouseRepository.Any(s => s.Id == id && !s.IsDeleted);
            }).WithMessage("Warehouse not found").WithErrorCode("404"); ;
        }

    }
}
