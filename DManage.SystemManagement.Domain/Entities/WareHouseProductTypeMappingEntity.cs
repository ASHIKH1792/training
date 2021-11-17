using DManage.SystemManagement.Domain.Common;

namespace DManage.SystemManagement.Domain.Entities
{
    public class WareHouseProductTypeMapping:AuditEntity
    {
        public long ProductTypeId { get; set; }

        public int WareHouseId { get; set; }

        public ProductType ProductType { get; set; }

        public WareHouse WareHouse { get; set; }
    }
}
