using System.Collections.Generic;

namespace DManage.SystemManagement.Domain
{
    public class ConfigurationSettings
    {
        public string SqlServerConnectionString { get; set; }

        public int InitialiseDatabaseRetryCount { get; set; }

        public string EventBusConnection { get; set; }
        public int EventBusPort { get; set; }
        public string EventBusUserName { get; set; }
        public string EventBusPassword { get; set; }
        public int EventBusRetryCount { get; set; }

        public string EventBusVirtualHost { get; set; }
        public string SubscriptionClientName { get; set; }

        public string Authority { get; set; }

        public List<string> IssuerUri { get; set; }

        public string Audience { get; set; }

        public string ApiSecret { get; set; }
    }
}
