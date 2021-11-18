using AutoMapper;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.ResponseDto;
using DManage.SystemManagement.Domain.Interface;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries
{
    public class WareHouseProductTypeQueries : IWareHouseProductTypeQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public WareHouseProductTypeQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<WareHouseProductTypeDto> GetProductTypeByWareHouseId(int wareHouseId)
        {
            var result = await _unitOfWork.WareHouseProductTypeMappingRepository.FirstOrDefaultAsync(s => s.Id == wareHouseId && !s.IsDeleted);
            return _mapper.Map<WareHouseProductTypeDto>(result);
        }
    }
}
