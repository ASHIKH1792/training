using DManage.SystemManagement.Infrastructure.Common.Interface;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using System;

namespace DManage.SystemManagement.Infrastructure.Common.Service
{
    public class RetryMechanism : IRetryMechanism
    {
        private readonly ILogger<RetryMechanism> _logger;
        public RetryMechanism(ILogger<RetryMechanism> logger)
        {
            _logger = logger;
        }
        public AsyncRetryPolicy CreatePolicyAsync(int retries,int sleepduration, string actionName)
        {
            return Policy.Handle<Exception>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(sleepduration),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        _logger.LogWarning(exception, $"[{actionName}]: Exception {exception.GetType().Name} with message {exception.Message} detected on attempt {retry} of {retries}");
                    }
                );
        }

        public RetryPolicy CreatePolicy(int retries, int sleepduration, string actionName)
        {
            return Policy.Handle<Exception>().
                WaitAndRetry(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(sleepduration),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        _logger.LogWarning(exception, $"[{actionName}]: Exception {exception.GetType().Name} with message {exception.Message} detected on attempt {retry} of {retries}");
                    }
                );
        }
    }
}
