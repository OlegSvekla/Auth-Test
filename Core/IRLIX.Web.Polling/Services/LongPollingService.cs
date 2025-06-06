using IRLIX.Mq.Buses;
using IRLIX.Mq.Local.MediatR.Messages;
using IRLIX.Web.Polling.Provider;

namespace IRLIX.Web.Polling.Services;

public interface ILongPollingService
{
    Task<TResult?> WaitForAsync<TResult>(
        IMediatrQuery<TResult?> query,
        CancellationToken ct)
        where TResult : class;

    Task<TResult?> WaitForAsync<TResult>(
        IMediatrQuery<TResult?> query,
        CancellationToken ct)
        where TResult : struct;

    Task<bool> WaitForAsync(
        IMediatrQuery<bool> query,
        CancellationToken ct);
}

public class LongPollingService(
    ILocalMessageBus localMessageBus,
    ILongPollingConfigProvider longPollingConfigProvider
) : ILongPollingService
{
    private readonly int maxHttpConnectionTimeSec = longPollingConfigProvider.GetMaxHttpConnectionTimeSec();
    private readonly int delayAfterExecutionMilliseconds = longPollingConfigProvider.GetDelayAfterExecutionMilliseconds();

    public async Task<TResult?> WaitForAsync<TResult>(
        IMediatrQuery<TResult?> query,
        CancellationToken ct)
        where TResult : class
    {
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
        cts.CancelAfter(TimeSpan.FromSeconds(maxHttpConnectionTimeSec));

        while (!cts.IsCancellationRequested)
        {
            var result = await localMessageBus.DispatchAsync(
                query: query,
                ct);

            if (result is not null)
            {
                return result;
            }

            await Task.Delay(delayAfterExecutionMilliseconds, ct);
        }

        return null;
    }

    public async Task<TResult?> WaitForAsync<TResult>(
        IMediatrQuery<TResult?> query,
        CancellationToken ct)
        where TResult : struct
    {
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
        cts.CancelAfter(TimeSpan.FromSeconds(maxHttpConnectionTimeSec));

        while (!cts.IsCancellationRequested)
        {
            var result = await localMessageBus.DispatchAsync(
                query: query,
                ct);

            if (result is not null)
            {
                return result;
            }

            await Task.Delay(delayAfterExecutionMilliseconds, ct);
        }

        return null;
    }

    public async Task<bool> WaitForAsync(
        IMediatrQuery<bool> query,
        CancellationToken ct)
    {
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
        cts.CancelAfter(TimeSpan.FromSeconds(maxHttpConnectionTimeSec));

        while (!cts.IsCancellationRequested)
        {
            var result = await localMessageBus.DispatchAsync(
                query: query,
                ct);

            if (result)
            {
                return result;
            }

            await Task.Delay(delayAfterExecutionMilliseconds, ct);
        }

        return false;
    }
}
