using DManage.SystemManagement.API.Controllers.BaseController;
using DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler;
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
    public class WareHouseNodeController : BaseApiController
    {
        private readonly IWareHouseNodeQueries _queries;
        public WareHouseNodeController(IWareHouseNodeQueries queries)
        {
            _queries = queries;

        }
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> CreateWareHouseNode(WareHouseNodeCreateCommand command)
        {
            return await Mediator.Send(command);

        }

        [HttpGet("GetNodeByWareHouseId")]
        public async Task<ActionResult<WareHouseNodeDto>> GetNodeByWareHouseId(int wareHouseId)
        {
            return await _queries.GetNodesByWareHouseId(wareHouseId);

        }
    }
}
