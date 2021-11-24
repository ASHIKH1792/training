using AutoMapper;
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
        private IMapper _mapper;
        public PalletCreateCommandHandler(IUnitOfWork unitofWork, ICapPublisher capPublisher, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _capPublisher = capPublisher;
            _mapper = mapper;
        }
        public async Task<ResponseMessage> Handle(PalletCreateCommand request, CancellationToken cancellationToken)
        {
            Pallet pallet = _mapper.Map<Pallet>(request);
            _unitofWork.PalletRepository.Insert(pallet);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                await PublishMessage(pallet);

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

        private async Task PublishMessage(Pallet pallet)
        {
            var productType =await  _unitofWork.ProductTypeRepository.FirstOrDefaultAsync(s => s.Id == pallet.ProductTypeId,s=>new ProductType() {ReferenceId=s.ReferenceId });
            if (productType != null)
            {
                await _capPublisher.PublishAsync("SystemManage.Pallet.Create", new { Id = pallet.Id, Name = pallet.Name, Quantity = pallet.Quantity, ProductTypeReferenceId = productType.ReferenceId, EventId = Guid.NewGuid() });
            }
        }
    }
}
