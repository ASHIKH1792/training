using AutoMapper;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.ResponseDto;
using DManage.SystemManagement.Domain.Interface;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries
{
    public class PalletQueries : IPalletQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PalletQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PalletDto> GePalletById(int palletId)
        {
            var result= await _unitOfWork.PalletRepository.FirstOrDefaultAsync(s => s.Id == palletId && !s.IsDeleted, "ProductType");
            return _mapper.Map<PalletDto>(result);

        }
    }
}
