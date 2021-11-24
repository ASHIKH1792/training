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
    public class WareHouseProductTypeController : BaseApiController
    {
        private readonly IWareHouseProductTypeQueries _queries;
        public WareHouseProductTypeController(IWareHouseProductTypeQueries queries)
        {
            _queries = queries;

        }
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> CreateWareHouseProductType(WareHouseProductTypeCreateCommand command)
        {
            return await Mediator.Send(command);

        }

        [HttpGet("GetProductTypeByWareHouseId")]
        public async Task<ActionResult<WareHouseProductTypeDto>> GetProductTypeByWareHouseId(int wareHouseId)
        {
            return await _queries.GetProductTypeByWareHouseId(wareHouseId);

        }
    }
}
