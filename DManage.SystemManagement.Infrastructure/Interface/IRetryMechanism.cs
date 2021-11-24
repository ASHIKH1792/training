using Polly.Retry;

namespace DManage.SystemManagement.Infrastructure.Common.Interface
{
    public interface IRetryMechanism
    {
        AsyncRetryPolicy CreatePolicyAsync(int retries, int sleepduration, string actionName);

        RetryPolicy CreatePolicy(int retries, int sleepduration, string actionName);
    }
}
