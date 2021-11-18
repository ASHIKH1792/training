using AutoMapper;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.ResponseDto;
using DManage.SystemManagement.Domain.Interface;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries
{
    public class PalletLpnQueries : IPalletLpnQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PalletLpnQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PalletLpnDto> GetPalletByLpnId(int lpnId)
        {
            var result= await _unitOfWork.PalletLpnRepository.FirstOrDefaultAsync(s => s.LicensePlateNumberId == lpnId && !s.IsDeleted);
            return _mapper.Map<PalletLpnDto>(result);

        }
    }
}
