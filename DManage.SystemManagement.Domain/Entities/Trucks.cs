using DManage.SystemManagement.Domain.Common;

namespace DManage.SystemManagement.Domain.Entities
{
    public class Trucks:AuditEntity
    {
        public string RegistrationNumber { get; set; }

        public string Model { get; set; }
    }
}
