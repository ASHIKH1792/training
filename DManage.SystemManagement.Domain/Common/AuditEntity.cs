using System;

namespace DManage.SystemManagement.Domain.Common
{
    public class AuditEntity
    {
        public long Id { get; set; }

        public DateTime CreationTime { get; set; }

        public long CreationUserId { get; set; }

        public DateTime? UpdationTime { get; set; }

        public long? UpdationUserId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletionTime { get; set; }
    }
}
