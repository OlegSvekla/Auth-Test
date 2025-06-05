using IRLIX.Core.Core.General;
using IRLIX.Core.Enums;
using IRLIX.Core.Http.In;
using IRLIX.Core.Identity;
using IRLIX.Repository.Repository.Interfaces.Common;

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
