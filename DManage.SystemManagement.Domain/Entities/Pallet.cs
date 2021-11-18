using DManage.SystemManagement.Domain.Common;
using System;

namespace DManage.SystemManagement.Domain.Entities
{
    public class Pallet : AuditEntity
    {
        public new long Id { get; set; }
        public string Name { get; set; }
        public long ProductTypeId { get; set; }

        public long Quantity { get; set; }

        public ProductType ProductType{ get; set; }

    }
}
