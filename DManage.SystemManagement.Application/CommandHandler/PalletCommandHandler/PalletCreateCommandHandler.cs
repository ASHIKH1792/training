using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.PalletCommandHandler
{
    public class PalletCreateCommand : IRequest<ResponseMessage>
    {
        public string Name { get; set; }
        public long ProductTypeId { get; set; }

        public long Quantity { get; set; }
    }
    public class PalletCreateCommandHandler : IRequestHandler<PalletCreateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        public PalletCreateCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseMessage> Handle(PalletCreateCommand request, CancellationToken cancellationToken)
        {
            Pallet pallet = new Pallet() { Name = request.Name,ProductTypeId=request.ProductTypeId,Quantity=request.Quantity };
            _unitofWork.PalletRepository.Insert(pallet);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponseMessage()
                {
                    Id = pallet.Id,
                    Message = ResponseMessageConstant.Success
                };
            }
            else {

                return new ResponseMessage()
                {
                    Message = ResponseMessageConstant.Failed
                };
            }
        }
    }
}
