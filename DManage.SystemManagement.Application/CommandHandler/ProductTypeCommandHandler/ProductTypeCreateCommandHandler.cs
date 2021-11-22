using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using DotNetCore.CAP;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.ProductTypeCommandHandler
{
    public class ProductTypeCreateCommand : IRequest<ResponseMessage>
    {
        public string Name { get; set; }
    }
    public class ProductTypeCreateCommandHandler : IRequestHandler<ProductTypeCreateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly ICapPublisher _capPublisher;
        public ProductTypeCreateCommandHandler(IUnitOfWork unitofWork, ICapPublisher capPublisher)
        {
            _unitofWork = unitofWork;
            _capPublisher = capPublisher;
        }
        public async Task<ResponseMessage> Handle(ProductTypeCreateCommand request, CancellationToken cancellationToken)
        {
            ProductType productType = new ProductType() { Name = request.Name };
            _unitofWork.ProductTypeRepository.Insert(productType);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                await PublishMessage(productType);
                return new ResponseMessage()
                {
                    Id = productType.Id,
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

        private async Task PublishMessage(ProductType productType)
        {
            await _capPublisher.PublishAsync("SystemManage.ProductType.Create", new { ProductTypeReferenceId=productType.ReferenceId, ProductTypeName = productType.Name,EventId=Guid.NewGuid() });
        }
    }
}
