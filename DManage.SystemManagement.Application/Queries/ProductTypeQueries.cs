using AutoMapper;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.ResponseDto;
using DManage.SystemManagement.Domain.Interface;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Application.Queries
{
    public class ProductTypeQueries : IProductTypeQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductTypeQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductTypeDto> GetProductTypeById(int productTypeId)
        {
            var result= await _unitOfWork.ProductTypeRepository.FirstOrDefaultAsync(s => s.Id == productTypeId && !s.IsDeleted);
            return _mapper.Map<ProductTypeDto>(result);

        }
    }
}
