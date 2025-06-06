using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.Core.General;
using IRLIX.Ef.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IRLIX.BL.Shared.Modifiers.Updaters;

public interface ISessionsExpirationUpdater
{
    Task SetSessionExpiredAsync(
        Guid sessionId,
        CancellationToken ct);

    Task SetAllSessionsExpiredAsync(
        Guid userId,
        CancellationToken ct);
}

internal class SessionsExpirationUpdater(
    IRepository<SessionEntity> sessionRepository,
    IUow uow
    ) : ISessionsExpirationUpdater
{
    public async Task SetSessionExpiredAsync(
        Guid sessionId,
        CancellationToken ct)
    {
        var session = await sessionRepository.GetByIdAsync(
            id: sessionId,
            selector: x => x,
            behavior: QueryTrackingBehavior.TrackAll,
            ct: ct);
        session.RefreshTokenExpiresAt = default;
        await sessionRepository.UpdateAsync(session, x => x.RefreshTokenExpiresAt, ct);

        await uow.CommitAsync(ct);
    }

    public async Task SetAllSessionsExpiredAsync(
        Guid userId,
        CancellationToken ct)
    {
        var sessions = await sessionRepository.GetAllAsync(
            predicate: x
                => x.UserId == userId
                && x.RefreshTokenExpiresAt != default,
            selector: x => x,
            behavior: QueryTrackingBehavior.TrackAll,
            ct: ct);

        await sessions.ForEachAsync(async session =>
        {
            session.RefreshTokenExpiresAt = default;
            await sessionRepository.UpdateAsync(session, x => x.RefreshTokenExpiresAt, ct);
        });

        await uow.CommitAsync(ct);
    }
}
