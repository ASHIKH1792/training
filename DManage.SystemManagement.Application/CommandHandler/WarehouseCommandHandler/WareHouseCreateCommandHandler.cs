using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler
{
    public class WareHouseCreateCommand : IRequest<ResponseMessage>
    {
        public string Name { get; set; }
    }
    public class WareHouseCreateCommandHandler : IRequestHandler<WareHouseCreateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        public WareHouseCreateCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseMessage> Handle(WareHouseCreateCommand request, CancellationToken cancellationToken)
        {
            WareHouse warehouse = new WareHouse() { Name = request.Name };
            _unitofWork.WareHouseRepository.Insert(warehouse);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponseMessage()
                {
                    Id = warehouse.Id,
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
