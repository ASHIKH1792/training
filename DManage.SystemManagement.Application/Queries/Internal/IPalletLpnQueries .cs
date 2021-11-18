using DManage.SystemManagement.Application.ResponseDto;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries.Internal
{
    public interface IPalletLpnQueries
    {
        Task<PalletLpnDto> GetPalletByLpnId(int lpnId);
    }
}
