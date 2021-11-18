using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.PalletCommandHandler
{
    public class PalletLpnCreateCommand : IRequest<ResponseMessage>
    {
        public long PalletId { get; set; }

        public long LicensePlateNumberId { get; set; }
    }
    public class PalletLpnCreateCommandHandler : IRequestHandler<PalletLpnCreateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        public PalletLpnCreateCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseMessage> Handle(PalletLpnCreateCommand request, CancellationToken cancellationToken)
        {
            PalletLpnMapping palletLpn = new PalletLpnMapping() { PalletId = request.PalletId, LicensePlateNumberId=request.LicensePlateNumberId };
            _unitofWork.PalletLpnRepository.Insert(palletLpn);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponseMessage()
                {
                    Id = palletLpn.Id,
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
