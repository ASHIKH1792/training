using AutoMapper;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.ResponseDto;
using DManage.SystemManagement.Domain.Interface;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries
{
    public class WareHouseQueries: IWareHouseQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public WareHouseQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<WareHouseDto> GetWareHouseById(int warehouseId)
        {
            var result= await _unitOfWork.WareHouseRepository.FirstOrDefaultAsync(s => s.Id == warehouseId && !s.IsDeleted);
            return _mapper.Map<WareHouseDto>(result);

        }
    }
}
