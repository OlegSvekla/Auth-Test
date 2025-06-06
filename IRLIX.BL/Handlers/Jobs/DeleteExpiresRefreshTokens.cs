using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.Context;
using IRLIX.Core.Interfaces.Jobs;
using IRLIX.Core.Time;
using IRLIX.Ef.Repositories;
using IRLIX.Jobs.Hangfire.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IRLIX.BL.Handlers.Jobs;

public interface IDeleteExpiresRefreshTokens
{
    Task ExecuteAsync(CancellationToken ct);
}

public class DeleteExpiresRefreshTokens(
    ILogger<BaseJobWrapper> logger,
    ICallContextInitializer callContextInitializer,
    ICallContextProvider callContextProvider,
    IDateTimeProvider dateTimeProvider,
    IRepository<SessionEntity> sessionRepository,
    IJobExecutor jobExecutor,
    IUow uow
    ) : BaseJobWrapper(
            logger,
            callContextInitializer,
            callContextProvider),
        IDeleteExpiresRefreshTokens

{
    public async Task ExecuteAsync(CancellationToken ct)
    {
        jobExecutor.RecurringEveryMinutes<DeleteExpiresRefreshTokens>(
            executor => executor.RunInsideJobAsync(null, ct),
            1);
    }

    protected override async Task InnerRunAsync(object? payload, CancellationToken ct)
    {
        var batchSize = 300;

        while (!ct.IsCancellationRequested)
        {
            var expiredSessions = await sessionRepository.GetAllAsync(
                selector: e => e,
                amount: batchSize,
                offset: 0,
                predicate: s => s.RefreshTokenExpiresAt < dateTimeProvider.UtcNow(),
                sorter: query => query.OrderBy(s => s.Id),
                behavior: QueryTrackingBehavior.TrackAll,
                ct: ct);

            if (expiredSessions.Count == 0)
                break;

            await DeleteSessionsAsync(expiredSessions, ct);
        }
    }

    private async Task DeleteSessionsAsync(IList<SessionEntity> sessions, CancellationToken ct)
    {
        foreach (var session in sessions)
        {
            await sessionRepository.DeleteAsync(session, ct);         
        }

        await uow.CommitAsync(ct);
    }
}