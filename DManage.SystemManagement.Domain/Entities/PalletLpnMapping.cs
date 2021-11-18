using DManage.SystemManagement.Domain.Common;

namespace DManage.SystemManagement.Domain.Entities
{
    public class PalletLpnMapping:AuditEntity
    {

        public long PalletId { get; set; }

        public long LicensePlateNumberId { get; set; }

        public Pallet Pallet { get; set; }
        public LicensePlateNumber LicensePlateNumber { get; set; }
    }
}
