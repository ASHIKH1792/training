using DManage.SystemManagement.Domain.Common;

namespace DManage.SystemManagement.Domain.Entities
{
    public class LicensePlateNumber : AuditEntity
    {
        public new long Id { get; set; }
        public int NodeId { get; set; }

        public Node Node { get; set; }
    }
}
