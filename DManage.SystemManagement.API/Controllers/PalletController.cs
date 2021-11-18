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
    public class PalletController : BaseApiController
    {
        private readonly IPalletQueries _queries;
        public PalletController(IPalletQueries queries)
        {
            _queries = queries;

        }
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> CreateNode(PalletCreateCommand command)
        {
            return await Mediator.Send(command);

        }

        [HttpGet("GePalletById")]
        public async Task<ActionResult<PalletDto>> GePalletById(int palletId)
        {
            return await _queries.GePalletById(palletId);

        }
    }
}
