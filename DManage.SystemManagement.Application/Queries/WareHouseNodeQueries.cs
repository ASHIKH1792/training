using AutoMapper;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.ResponseDto;
using DManage.SystemManagement.Domain.Interface;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries
{
    public class WareHouseNodeQueries : IWareHouseNodeQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public WareHouseNodeQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<WareHouseNodeDto> GetNodesByWareHouseId(int wareHouseId)
        {
            var result= await _unitOfWork.WareHouseNodeMappingRepository.FirstOrDefaultAsync(s => s.WarehouseId == wareHouseId && !s.IsDeleted);
            return _mapper.Map<WareHouseNodeDto>(result);

        }
    }
}
