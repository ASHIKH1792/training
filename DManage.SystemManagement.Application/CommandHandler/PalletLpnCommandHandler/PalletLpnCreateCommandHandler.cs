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
    public class PalletLpnCreateCommand : IRequest<ResponseMessage>
    {
        public long PalletId { get; set; }

        public long LicensePlateNumberId { get; set; }
    }
    public class PalletLpnCreateCommandHandler : IRequestHandler<PalletLpnCreateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly ICapPublisher _cappublisher;
        public PalletLpnCreateCommandHandler(IUnitOfWork unitofWork, ICapPublisher cappublisher)
        {
            _unitofWork = unitofWork;
            _cappublisher = cappublisher;
        }
        public async Task<ResponseMessage> Handle(PalletLpnCreateCommand request, CancellationToken cancellationToken)
        {
            PalletLpnMapping palletLpn = new PalletLpnMapping() { PalletId = request.PalletId, LicensePlateNumberId=request.LicensePlateNumberId };
            _unitofWork.PalletLpnRepository.Insert(palletLpn);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                await PublishMessage(request.PalletId,request.LicensePlateNumberId);
                return new ResponseMessage()
                {
                    Id = palletLpn.Id,
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

        private async Task PublishMessage(long palletId,long lpnId)
        {
            LicensePlateNumber lpn = await _unitofWork.LicensePlateNumberRepository.FirstOrDefaultAsync(s => s.Id == lpnId,
                s=>new LicensePlateNumber() {Id=s.Id,Node=new Node() {Name=s.Node.Name } }, "Node");
            await _cappublisher.PublishAsync("SystemManage.Lpn.Create", new { LpnId = lpn.Id, NodeName = lpn.Node.Name, PalletId = palletId,EventId=Guid.NewGuid() });
        }
    }
}
