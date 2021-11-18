using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler
{
    public class WareHouseProductTypeCreateCommand : IRequest<ResponseMessage>
    {
        public long ProductTypeId { get; set; }
        public int WarehouseId { get; set; }
    }
    public class WareHouseProductTypeCreateCommandHandler : IRequestHandler<WareHouseProductTypeCreateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        public WareHouseProductTypeCreateCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseMessage> Handle(WareHouseProductTypeCreateCommand request, CancellationToken cancellationToken)
        {
            WareHouseProductTypeMapping wareHouseProductType = new WareHouseProductTypeMapping() { ProductTypeId = request.ProductTypeId,WareHouseId=request.WarehouseId };
            _unitofWork.WareHouseProductTypeMappingRepository.Insert(wareHouseProductType);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponseMessage()
                {
                    Id = wareHouseProductType.Id,
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
