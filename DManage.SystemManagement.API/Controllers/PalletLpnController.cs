using DManage.SystemManagement.API.Controllers.BaseController;
using DManage.SystemManagement.Application.CommandHandler.PalletCommandHandler;
using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.ResponseDto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DManage.SystemManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalletLpnController : BaseApiController
    {
        private readonly IPalletLpnQueries _queries;
        public PalletLpnController(IPalletLpnQueries queries)
        {
            _queries = queries;

        }
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> CreateNode(PalletLpnCreateCommand command)
        {
            return await Mediator.Send(command);

        }

        [HttpGet("GetPalletByLpnId")]
        public async Task<ActionResult<PalletLpnDto>> GetPalletByLpnId(int lpnId)
        {
            return await _queries.GetPalletByLpnId(lpnId);

        }
    }
}
