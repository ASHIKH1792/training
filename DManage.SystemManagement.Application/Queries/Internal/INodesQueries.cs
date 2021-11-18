using DManage.SystemManagement.Application.ResponseDto;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries.Internal
{
    public interface INodesQueries
    {
        Task<NodeDto> GetNodeById(int nodeId);
    }
}
