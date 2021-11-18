using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using DotNetCore.CAP;
using MediatR;
using System;
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
        private readonly ICapPublisher _capPublisher;
        public PalletCreateCommandHandler(IUnitOfWork unitofWork, ICapPublisher capPublisher)
        {
            _unitofWork = unitofWork;
            _capPublisher = capPublisher;
        }
        public async Task<ResponseMessage> Handle(PalletCreateCommand request, CancellationToken cancellationToken)
        {
            Pallet pallet = new Pallet() { Name = request.Name,ProductTypeId=request.ProductTypeId,Quantity=request.Quantity };
            _unitofWork.PalletRepository.Insert(pallet);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                 _capPublisher.Publish("SystemManage.Pallet.Create",new {Id=pallet.Id,Name=pallet.Name, ProductTypeId=pallet.ProductTypeId, Quantity=pallet.Quantity,EventId=Guid.NewGuid() });
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
