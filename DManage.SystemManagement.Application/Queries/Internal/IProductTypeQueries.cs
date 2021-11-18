using DManage.SystemManagement.Application.ResponseDto;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries.Internal
{
    public interface IProductTypeQueries
    {
        Task<ProductTypeDto> GetProductTypeById(int productTypeId);
    }
}
