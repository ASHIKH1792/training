using DManage.SystemManagement.API.Controllers.BaseController;
using DManage.SystemManagement.Application.CommandHandler.NodeCommandHandler;
using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.ResponseDto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DManage.SystemManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LpnController : BaseApiController
    {
        private readonly ILpnQueries _queries;
        public LpnController(ILpnQueries queries)
        {
            _queries = queries;

        }
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> CreateLpn(LpnCreateCommand command)
        {
            return await Mediator.Send(command);

        }

        [HttpGet("GetLpnById")]
        public async Task<ActionResult<LpnDto>> GetNodeById(int lpnId)
        {
            return await _queries.GetLpnById(lpnId);

        }
    }
}
