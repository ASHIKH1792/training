using DManage.SystemManagement.Application.ResponseDto;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries.Internal
{
    public interface IWareHouseNodeQueries
    {
        Task<WareHouseNodeDto> GetNodesByWareHouseId(int wareHouseId);
    }
}
