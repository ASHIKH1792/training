using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.CommandHandler.NodeCommandHandler
{
    public class NodeCreateCommand : IRequest<ResponseMessage>
    {
        public string Name { get; set; }
    }
    public class NodeCreateCommandHandler : IRequestHandler<NodeCreateCommand, ResponseMessage>
    {
        private readonly IUnitOfWork _unitofWork;
        public NodeCreateCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseMessage> Handle(NodeCreateCommand request, CancellationToken cancellationToken)
        {
            Node node = new Node() { Name = request.Name };
            _unitofWork.NodeRepository.Insert(node);
            int result= await _unitofWork.CommitAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponseMessage()
                {
                    Id = node.Id,
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
