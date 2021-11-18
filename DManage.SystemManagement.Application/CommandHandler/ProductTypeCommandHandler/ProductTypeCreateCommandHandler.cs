using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using MediatR;
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
        public ProductTypeCreateCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseMessage> Handle(ProductTypeCreateCommand request, CancellationToken cancellationToken)
        {
            ProductType productType = new ProductType() { Name = request.Name };
            _unitofWork.ProductTypeRepository.Insert(productType);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
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
    }
}
