using DManage.SystemManagement.Domain.Common;

namespace DManage.SystemManagement.Domain.Entities
{
    public class ProductType: AuditEntity
    {
        public new long Id { get; set; }
        public string Name { get; set; }
    }
}
