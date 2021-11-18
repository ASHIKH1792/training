using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Domain.Interface;
using DManage.SystemManagement.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SystemManagementDbContext _dbContext;
        public UnitOfWork(SystemManagementDbContext dbContext,
            IRepository<WareHouse> wareHouseRepository,
            IRepository<WareHouseNodeMapping> wareHouseNodeMappingRepository,
            IRepository<WareHouseProductTypeMapping> wareHouseProductTypeMappingRepository,
            IRepository<Node> nodeRepository,
            IRepository<LicensePlateNumber> licensePlateNumberRepository,
            IRepository<Pallet> palletRepository,
            IRepository<ProductType> productTypeRepository,
            IRepository<PalletLpnMapping> palletLpnRepository)
        {
            WareHouseRepository = wareHouseRepository;
            WareHouseNodeMappingRepository = wareHouseNodeMappingRepository;
            WareHouseProductTypeMappingRepository = wareHouseProductTypeMappingRepository;
            NodeRepository = nodeRepository;
            LicensePlateNumberRepository = licensePlateNumberRepository;
            PalletRepository = palletRepository;
            ProductTypeRepository = productTypeRepository;
            PalletLpnRepository = palletLpnRepository;
            _dbContext = dbContext;
        }
        public IRepository<WareHouse> WareHouseRepository { get; }
        public IRepository<Pallet> PalletRepository { get; }
        public IRepository<PalletLpnMapping> PalletLpnRepository { get; }
        public IRepository<ProductType> ProductTypeRepository { get; }
        public IRepository<LicensePlateNumber> LicensePlateNumberRepository { get; }

        public IRepository<WareHouseNodeMapping> WareHouseNodeMappingRepository { get; }
        public IRepository<WareHouseProductTypeMapping> WareHouseProductTypeMappingRepository { get; }

        public IRepository<Node> NodeRepository { get; }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
           return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
