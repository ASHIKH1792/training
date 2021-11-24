using DManage.SystemManagement.API.Controllers.BaseController;
using DManage.SystemManagement.Application.CommandHandler.NodeCommandHandler;
using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.ResponseDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DManage.SystemManagement.API.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class NodesController : BaseApiController
    {
        private readonly INodesQueries _queries;
        public NodesController(INodesQueries queries)
        {
            _queries = queries;

        }
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> CreateNode(NodeCreateCommand command)
        {
            return await Mediator.Send(command);

        }

        [HttpGet("GetNodeById")]
        public async Task<ActionResult<NodeDto>> GetNodeById(int nodeId)
        {
            return await _queries.GetNodeById(nodeId);

        }
    }
}
