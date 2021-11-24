using DManage.SystemManagement.API.Controllers.BaseController;
using DManage.SystemManagement.Application.CommandHandler.PalletCommandHandler;
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
    [Authorize(Roles ="Admin")]
    public class PalletLpnController : BaseApiController
    {
        private readonly IPalletLpnQueries _queries;
        public PalletLpnController(IPalletLpnQueries queries)
        {
            _queries = queries;

        }
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> CreatePalletLpnMapping(PalletLpnCreateCommand command)
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
