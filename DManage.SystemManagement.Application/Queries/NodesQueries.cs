using AutoMapper;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.ResponseDto;
using DManage.SystemManagement.Domain.Interface;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries
{
    public class NodesQueries : INodesQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NodesQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<NodeDto> GetNodeById(int nodeId)
        {
            var result= await _unitOfWork.NodeRepository.FirstOrDefaultAsync(s => s.Id == nodeId && !s.IsDeleted);
            return _mapper.Map<NodeDto>(result);

        }
    }
}
