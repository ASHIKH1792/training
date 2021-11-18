using DManage.SystemManagement.Domain.Interface;
using FluentValidation;

namespace DManage.SystemManagement.Application.CommandHandler.NodeCommandHandler.Validator
{
    public class LpnCreateValidatorHandler : AbstractValidator<LpnCreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public LpnCreateValidatorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.NodeId).MustAsync(async (id, cancellation) =>
            {
                return await _unitOfWork.NodeRepository.Any(s => s.Id == id && !s.IsDeleted);
            }).WithMessage("Node not found").WithErrorCode("404"); ;
        }

    }
}
