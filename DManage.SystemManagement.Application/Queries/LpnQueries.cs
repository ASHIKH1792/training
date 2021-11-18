using AutoMapper;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.ResponseDto;
using DManage.SystemManagement.Domain.Interface;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries
{
    public class LpnQueries : ILpnQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LpnQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LpnDto> GetLpnById(int lpnId)
        {
            var result= await _unitOfWork.LicensePlateNumberRepository.FirstOrDefaultAsync(s => s.Id == lpnId && !s.IsDeleted);
            return _mapper.Map<LpnDto>(result);

        }
    }
}
