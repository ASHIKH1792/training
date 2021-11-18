using DManage.SystemManagement.Domain.Interface;
using FluentValidation;

namespace DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler.Validator
{
    public class WareHouseNodeCreateValidatorHandler : AbstractValidator<WareHouseNodeCreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public WareHouseNodeCreateValidatorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.NodeId).MustAsync(async (id, cancellation) =>
            {
                return await _unitOfWork.NodeRepository.Any(s => s.Id == id && !s.IsDeleted);
            }).WithMessage("NodeId not found").WithErrorCode("404"); ;

            RuleFor(x => x.WarehouseId).MustAsync(async (id, cancellation) =>
            {
                return await _unitOfWork.WareHouseRepository.Any(s => s.Id == id && !s.IsDeleted);
            }).WithMessage("WarehouseId not found").WithErrorCode("404"); ;
        }

    }
}
