using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler
{
    public class WareHouseDeleteCommand : IRequest<ResponseMessage>
    {
        public int Id { get; set; }
    }
    public class WareHouseDeleteCommandHandler : IRequestHandler<WareHouseDeleteCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        public WareHouseDeleteCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseMessage> Handle(WareHouseDeleteCommand request, CancellationToken cancellationToken)
        {
            _unitofWork.WareHouseRepository.DeleteById(request.Id);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponseMessage()
                {
                    Id = request.Id,
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
