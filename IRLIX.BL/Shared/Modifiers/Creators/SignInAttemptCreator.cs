using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.Aggregator.Ef.Enums.Auth;
using IRLIX.Core.General;
using IRLIX.Ef.Repositories;
using IRLIX.Http.In;

namespace IRLIX.BL.Shared.Modifiers.Creators;

public interface ISignInAttemptCreator
{
    Task<Guid> CreateAsync(
        string deviceId,
        Guid userId,
        UserSignInAttemptType type,
        CancellationToken ct);
}

internal class SignInAttemptCreator(
    IHttpContextDataSearcher httpContextDataSearcher,
    IRepository<SignInAttemptEntity> signInAttemptRepository,
    IUow uow
    ) : ISignInAttemptCreator
{
    public async Task<Guid> CreateAsync(
        string deviceId,
        Guid userId,
        UserSignInAttemptType type,
        CancellationToken ct)
    {
        var ip = httpContextDataSearcher.FindIp().GetValue();
        var userAgent = httpContextDataSearcher.FindUserAgent().GetValue();

        var userAttemptSessionEntity = new SignInAttemptEntity
        {
            DeviceId = deviceId,
            Ip = ip,
            UserAgent = userAgent,
            Type = type,
            UserId = userId
        };

        var signInAttempt = await signInAttemptRepository.CreateAsync(userAttemptSessionEntity, ct);
        await uow.CommitAsync(ct);

        return signInAttempt.Id;
    }
}
