using DManage.SystemManagement.API.Controllers.BaseController;
using DManage.SystemManagement.Application.CommandHandler.DriverCommandHandler;
using DManage.SystemManagement.Application.Common.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DManage.SystemManagement.API.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class DriverController : BaseApiController
    {
        [HttpPost]
        public async Task<ResponseMessage> CreateDriver(DriverCreateCommand  command)
        {
            return await Mediator.Send(command);
        }
    }
}
