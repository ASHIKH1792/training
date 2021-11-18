using DManage.SystemManagement.Application.ResponseDto;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries.Internal
{
    public interface IWareHouseProductTypeQueries
    {
        Task<WareHouseProductTypeDto> GetProductTypeByWareHouseId(int wareHouseId);
    }
}
