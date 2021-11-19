using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.DriverCommandHandler
{
    public class DriverCreateCommand : IRequest<ResponseMessage>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }
    }
    public class DriverCreateCommandHandler : IRequestHandler<DriverCreateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        public DriverCreateCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseMessage> Handle(DriverCreateCommand request, CancellationToken cancellationToken)
        {
            Drivers driver = new Drivers() { FirstName = request.FirstName, LastName = request.LastName, MobileNumber=request.MobileNumber };
            _unitofWork.DriverRepository.Insert(driver);
            int result = await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponseMessage()
                {
                    Id = driver.Id,
                    Message = ResponseMessageConstant.Success
                };
            }
            else
            {

                return new ResponseMessage()
                {
                    Message = ResponseMessageConstant.Failed
                };
            }
        }
    }
}
