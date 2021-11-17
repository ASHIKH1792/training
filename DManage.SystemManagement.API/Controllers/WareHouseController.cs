using DManage.SystemManagement.API.Controllers.BaseController;
using DManage.SystemManagement.Application.CommandHandler.WarehouseCommandHandler;
using DManage.SystemManagement.Application.Common.Internal;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.ResponseDto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DManage.SystemManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : BaseApiController
    {
        private readonly IWareHouseQueries _wareHouseQueries;
        public WareHouseController(IWareHouseQueries wareHouseQueries)
        {
            _wareHouseQueries = wareHouseQueries;

        }
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> CreateWareHouse(WareHouseCreateCommand command)
        {
            return await Mediator.Send(command);

        }

        [HttpPut]
        public async Task<ActionResult<ResponseMessage>> UpdateWareHouse(WareHouseUpdateCommand command)
        {
            return await Mediator.Send(command);

        }

        [HttpDelete]
        public async Task<ActionResult<ResponseMessage>> DeleteWareHouse(WareHouseDeleteCommand command)
        {
            return await Mediator.Send(command);

        }

        [HttpGet("GetWareHouseById")]
        public async Task<ActionResult<WareHouseDto>> GetWareHouseById(int warehouseId)
        {
            return await _wareHouseQueries.GetWareHouseById(warehouseId);

        }
    }
}
