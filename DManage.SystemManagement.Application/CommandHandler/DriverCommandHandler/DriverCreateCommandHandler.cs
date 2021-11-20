using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using DotNetCore.CAP;
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
        private readonly ICapPublisher _capPublisher;
        public DriverCreateCommandHandler(IUnitOfWork unitofWork, ICapPublisher capPublisher)
        {
            _unitofWork = unitofWork;
            _capPublisher = capPublisher;
        }
        public async Task<ResponseMessage> Handle(DriverCreateCommand request, CancellationToken cancellationToken)
        {
            Drivers driver = new Drivers() { FirstName = request.FirstName, LastName = request.LastName, MobileNumber=request.MobileNumber };
            _unitofWork.DriverRepository.Insert(driver);
            int result = await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                await PublishMessage(driver);
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
        private async Task PublishMessage(Drivers driver)
        {
            await _capPublisher.PublishAsync("SystemManage.Truck.Create", new { Id = driver.Id, FirstName = driver.FirstName, LastName = driver.LastName, MobileNumber = driver.MobileNumber });
        }
    }
}
