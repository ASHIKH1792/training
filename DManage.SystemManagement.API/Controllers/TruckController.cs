using DManage.SystemManagement.API.Controllers.BaseController;
using DManage.SystemManagement.Application.CommandHandler.TruckCommandHandler;
using DManage.SystemManagement.Application.Common.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DManage.SystemManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : BaseApiController
    {
        [HttpPost]
        public async Task<ResponseMessage> CreateTruck(TruckCreateCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
