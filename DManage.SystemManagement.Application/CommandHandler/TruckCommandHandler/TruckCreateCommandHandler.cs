using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using DotNetCore.CAP;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.TruckCommandHandler
{
    public class TruckCreateCommand : IRequest<ResponseMessage>
    {
        public string RegistrationNumber { get; set; }

        public string Model { get; set; }
    }
    public class TruckCreateCommandHandler : IRequestHandler<TruckCreateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly ICapPublisher _capPublisher;
        public TruckCreateCommandHandler(IUnitOfWork unitofWork, ICapPublisher capPublisher)
        {
            _unitofWork = unitofWork;
            _capPublisher = capPublisher;
        }
        public async Task<ResponseMessage> Handle(TruckCreateCommand request, CancellationToken cancellationToken)
        {
            Trucks truck = new Trucks() { RegistrationNumber = request.RegistrationNumber,Model=request.Model };
            _unitofWork.TruckRepository.Insert(truck);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                await PublishMessage(truck);
                return new ResponseMessage()
                {
                    Id = truck.Id,
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

        private async Task PublishMessage(Trucks truck)
        {
            await _capPublisher.PublishAsync("SystemManage.Truck.Create", new { Id = truck.Id, RegistrationNumber = truck.RegistrationNumber, Model = truck.Model });
        }
    }
}
