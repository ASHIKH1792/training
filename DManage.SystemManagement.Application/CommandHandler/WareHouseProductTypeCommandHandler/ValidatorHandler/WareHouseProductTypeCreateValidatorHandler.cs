using DManage.SystemManagement.Domain.Interface;
using FluentValidation;

namespace DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler.Validator
{
    public class WareHouseProductTypeCreateValidatorHandler : AbstractValidator<WareHouseProductTypeCreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public WareHouseProductTypeCreateValidatorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.ProductTypeId).MustAsync(async (id, cancellation) =>
            {
                return await _unitOfWork.ProductTypeRepository.Any(s => s.Id == id && !s.IsDeleted);
            }).WithMessage("ProductTypeId not found").WithErrorCode("404"); ;

            RuleFor(x => x.WarehouseId).MustAsync(async (id, cancellation) =>
            {
                return await _unitOfWork.WareHouseRepository.Any(s => s.Id == id && !s.IsDeleted);
            }).WithMessage("WarehouseId not found").WithErrorCode("404"); ;
        }

    }
}
