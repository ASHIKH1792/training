using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler
{
    public class WareHouseNodeCreateCommand : IRequest<ResponseMessage>
    {
        public int NodeId { get; set; }
        public int WarehouseId { get; set; }
    }
    public class WareHouseNodeCreateCommandHandler : IRequestHandler<WareHouseNodeCreateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        public WareHouseNodeCreateCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseMessage> Handle(WareHouseNodeCreateCommand request, CancellationToken cancellationToken)
        {
            WareHouseNodeMapping wareHouseNode = new WareHouseNodeMapping() { NodeId = request.NodeId,WarehouseId=request.WarehouseId };
            _unitofWork.WareHouseNodeMappingRepository.Insert(wareHouseNode);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponseMessage()
                {
                    Id = wareHouseNode.Id,
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
