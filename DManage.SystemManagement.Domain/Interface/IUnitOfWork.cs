using DManage.SystemManagement.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Domain.Interface
{
    public interface IUnitOfWork
    {
        IRepository<WareHouse> WareHouseRepository { get; }
        IRepository<Pallet> PalletRepository { get; }

        IRepository<PalletLpnMapping> PalletLpnRepository { get; }

        IRepository<ProductType> ProductTypeRepository { get; }
        IRepository<LicensePlateNumber> LicensePlateNumberRepository { get; }

        IRepository<WareHouseNodeMapping> WareHouseNodeMappingRepository { get; }
        IRepository<WareHouseProductTypeMapping> WareHouseProductTypeMappingRepository { get; }

        IRepository<Node> NodeRepository { get; }

        IRepository<Trucks> TruckRepository { get; }

        IRepository<Drivers> DriverRepository { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
