using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.Auth.Contracts.Commands.TokenUpdates;
using IRLIX.BL.Shared.Modifiers.Updaters;
using IRLIX.Ef.Repositories;
using IRLIX.Ef.Repositories.Enums;
using IRLIX.Mq.Local.MediatR.Handlers;

namespace IRLIX.BL.Handlers.Commands;

internal class SignMeOutCommandHandler(
    IRepository<SessionEntity> sessionRepository,
    ISessionsExpirationUpdater sessionsExpirationUpdater
    ) : MediatrCommandHandler<SignMeOutCommand>
{
    public override async ValueTask HandleAsync(
        SignMeOutCommand command,
        CancellationToken ct)
    {
        var dto = await sessionRepository.FindAsync(
            mode: SearchModeEnum.Single,
            predicate: session
                => session.RefreshToken == command.RefreshToken
                && session.DeviceId == command.DeviceId,
            selector: session => new
            {
                SessionId = session.Id,
                session.UserId,
                session.DeviceId
            },
            ct: ct);
        if (dto == null)
        {
            return;
        }

        await sessionsExpirationUpdater.SetSessionExpiredAsync(dto.SessionId, ct);

        if (command.AllOpenSessions.HasValue
            && command.AllOpenSessions.Value)
        {
            await sessionsExpirationUpdater.SetAllSessionsExpiredAsync(dto.UserId, ct);
        }
    }
}
