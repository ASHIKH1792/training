using System;

namespace DManage.SystemManagement.Domain.Common
{
    public abstract class AuditEntity
    {
        public virtual int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public long CreationUserId { get; set; }

        public DateTime? UpdationTime { get; set; }

        public long? UpdationUserId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletionTime { get; set; }
    }
}
