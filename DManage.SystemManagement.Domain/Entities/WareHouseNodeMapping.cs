using DManage.SystemManagement.Domain.Common;

namespace DManage.SystemManagement.Domain.Entities
{
    public class WareHouseNodeMapping : AuditEntity
    {
        public int NodeId { get; set; }
        public int WarehouseId { get; set; }

        public WareHouse Warehouse { get; set; }
        public Node Node { get; set; }
    }
}
