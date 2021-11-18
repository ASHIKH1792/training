using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.NodeCommandHandler
{
    public class LpnCreateCommand : IRequest<ResponseMessage>
    {
        public int NodeId { get; set; }
    }
    public class LpnCreateCommandHandler : IRequestHandler<LpnCreateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        public LpnCreateCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseMessage> Handle(LpnCreateCommand request, CancellationToken cancellationToken)
        {
            LicensePlateNumber lpn = new LicensePlateNumber() { NodeId = request.NodeId };
            _unitofWork.LicensePlateNumberRepository.Insert(lpn);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponseMessage()
                {
                    Id = lpn.Id,
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
