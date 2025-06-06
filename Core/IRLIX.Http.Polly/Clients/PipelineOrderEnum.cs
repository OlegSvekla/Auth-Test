namespace IRLIX.Http.Polly.Clients;

public enum PipelineOrderEnum
{
    OneHttpRqTimeout,
    RateLimiter,
    Retry
}
