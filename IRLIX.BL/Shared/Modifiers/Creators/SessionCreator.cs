using IRLIX.Core.Core.General;
using IRLIX.Core.Entities;
using IRLIX.Core.Http.In;
using IRLIX.Core.Identity;
using IRLIX.Core.Identity.Tokens;
using Microsoft.EntityFrameworkCore;

namespace IRLIX.BL.Shared.Modifiers.Creators;

public interface ISessionCreator
{
    Task<Guid> CreateBySignInAttemptAsync(
        Guid userId,
        Guid signInAttemptId,
        CancellationToken ct);

    Task<Guid> CreateByRelatedSessionAsync(
        Guid userId,
        string deviceId,
        Guid relatedSessionId,
        CancellationToken ct);
}

internal class SessionCreator(
    IRefreshTokenGenerator refreshTokenGenerator,
    IRepository<SignInAttemptEntity> signInAttemptRepository,
    IRepository<SessionEntity> sessionRepository,
    IUow uow,
    IHttpContextDataSearcher httpContextDataSearcher
    ) : ISessionCreator
{
    public async Task<Guid> CreateBySignInAttemptAsync(
        Guid userId,
        Guid signInAttemptId,
        CancellationToken ct)
    {
        var signInAttempt = await signInAttemptRepository.GetByIdAsync(
            id: signInAttemptId,
            selector: x => x,
            behavior: QueryTrackingBehavior.TrackAll,
            ct: ct);

        var (refreshToken, refreshTokenExpiresAt) = refreshTokenGenerator.Generate();

        var noTrackingSession = new SessionEntity
        {
            DeviceId = signInAttempt.DeviceId,
            Ip = signInAttempt.Ip,
            UserAgent = signInAttempt.UserAgent,
            RefreshToken = refreshToken,
            RefreshTokenExpiresAt = refreshTokenExpiresAt,
            UserId = userId,
            SignInAttempt = signInAttempt
        };
        var createdSession = await sessionRepository.CreateAsync(noTrackingSession, ct);
        await uow.CommitAsync(ct);

        return createdSession.Id;
    }

    public async Task<Guid> CreateByRelatedSessionAsync(
        Guid userId,
        string deviceId,
        Guid relatedSessionId,
        CancellationToken ct)
    {
        var ip = httpContextDataSearcher.FindIp().GetValue();
        var userAgent = httpContextDataSearcher.FindUserAgent().GetValue();

        var (refreshToken, refreshTokenExpiresAt) = refreshTokenGenerator.Generate();

        var noTrackingSession = new SessionEntity
        {
            DeviceId = deviceId,
            Ip = ip,
            UserAgent = userAgent,
            RefreshToken = refreshToken,
            RefreshTokenExpiresAt = refreshTokenExpiresAt,
            UserId = userId,
            RelatedSessionId = relatedSessionId
        };
        var createdSession = await sessionRepository.CreateAsync(noTrackingSession, ct);
        await uow.CommitAsync(ct);

        return createdSession.Id;
    }
}
