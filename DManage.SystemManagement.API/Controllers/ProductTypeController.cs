using DManage.SystemManagement.API.Controllers.BaseController;
using DManage.SystemManagement.Application.CommandHandler.ProductTypeCommandHandler;
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
    //[Authorize(Roles = "Admin")]
    public class ProductTypeController : BaseApiController
    {
        private readonly IProductTypeQueries _queries;
        public ProductTypeController(IProductTypeQueries queries)
        {
            _queries = queries;

        }
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> CreateProductType(ProductTypeCreateCommand command)
        {
            return await Mediator.Send(command);

        }

        [HttpGet("GetProductTypeById")]
        public async Task<ActionResult<ProductTypeDto>> GetProductTypeById(int productTypeId)
        {
            return await _queries.GetProductTypeById(productTypeId);

        }
    }
}
