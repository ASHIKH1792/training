using AutoMapper;
using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Application.IntegrationEventMessage;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using DotNetCore.CAP;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.ProductTypeCommandHandler
{
    public class ProductTypeCreateCommand : IRequest<ResponseMessage>
    {
        public List<string> Name { get; set; }
    }
    public class ProductTypeCreateCommandHandler : IRequestHandler<ProductTypeCreateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly ICapPublisher _capPublisher;
        private readonly IMapper _mapper;
        public ProductTypeCreateCommandHandler(IUnitOfWork unitofWork, ICapPublisher capPublisher, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _capPublisher = capPublisher;
            _mapper = mapper;
        }
        public async Task<ResponseMessage> Handle(ProductTypeCreateCommand request, CancellationToken cancellationToken)
        {
            List<ProductType> lstProductType = PopulateProductType(request);
            _unitofWork.ProductTypeRepository.InsertRange(lstProductType);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                await PublishMessage(lstProductType);
                return new ResponseMessage()
                {
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

        private List<ProductType> PopulateProductType(ProductTypeCreateCommand request)
        {
            return request.Name.Select(s=>new ProductType() {Name=s,ReferenceId=Guid.NewGuid() }).ToList();
        }

        private async Task PublishMessage(IEnumerable<ProductType> lstProductType)
        {
            await _capPublisher.PublishAsync("SystemManage.ProductType.Create", new ProductTypeIntegrationEventMessage() { ProductType = _mapper.Map<IEnumerable<ProductTypeEventMessage>>(lstProductType), EventId = Guid.NewGuid() });
        }
    }
}
