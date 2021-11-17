using DManage.SystemManagement.Domain.Common;

namespace DManage.SystemManagement.Domain.Entities
{
    public class WareHouse: AuditEntity
    {
        public string Name { get; set; }

        public int NodeCount { get; set; }
    }
}
