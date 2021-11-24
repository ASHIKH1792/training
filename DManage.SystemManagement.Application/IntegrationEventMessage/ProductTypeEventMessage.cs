using DManage.SystemManagement.Application.IntegrationEventMessage.Internal;
using System;
using System.Collections.Generic;

namespace DManage.SystemManagement.Application.IntegrationEventMessage
{
    public class ProductTypeEventMessage
    {
        public Guid ProductTypeReferenceId { get; set; }

        public string ProductTypeName { get; set; }
    }

    public class ProductTypeIntegrationEventMessage:IntegrationBaseMessage
    {
        
        public IEnumerable<ProductTypeEventMessage> ProductType { get; set; }


    }
}
