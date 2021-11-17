using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler
{
    public class WareHouseUpdateCommand : IRequest<ResponseMessage>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class WareHouseUpdateCommandHandler : IRequestHandler<WareHouseUpdateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        public WareHouseUpdateCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseMessage> Handle(WareHouseUpdateCommand request, CancellationToken cancellationToken)
        {
            WareHouse warehouse =await _unitofWork.WareHouseRepository.FirstOrDefaultAsync(s => s.Id == request.Id);
            if (warehouse != null)
            {
                _unitofWork.WareHouseRepository.Update(warehouse);
                int result = await _unitofWork.CommitAsync(cancellationToken);
                if (result > 0)
                {
                    return new ResponseMessage()
                    {
                        Id = warehouse.Id,
                        Message = ResponseMessageConstant.Success
                    };
                }
            }
            return new ResponseMessage()
            {
                Message = ResponseMessageConstant.Failed
            };
        }
    }
}
