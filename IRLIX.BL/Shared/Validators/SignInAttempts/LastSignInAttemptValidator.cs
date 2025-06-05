using IRLIX.Core.Core.General;
using IRLIX.Core.Enums;
using IRLIX.Core.Hashes;
using IRLIX.Core.Http.In;
using IRLIX.Core.Identity;
using IRLIX.Core.Time;
using IRLIX.Repository.Enums;

namespace IRLIX.BL.Shared.Modifiers.Validators.SignInAttempts;

public interface ILastSignInAttemptValidator
{
    Task<Guid> ValidateAndGetIdAsync(
        string deviceId,
        UserSignInAttemptType type,
        string code,
        Guid userId,
        string userName,
        CancellationToken ct);
}

internal class LastSignInAttemptValidator(
    IHttpContextDataSearcher httpContextDataSearcher,
    IRepository<SignInAttemptEntity> userSignInAttemptRepository,
    IDateTimeProvider dateTimeProvider,
    IHashClient hashClient
    ) : ILastSignInAttemptValidator
{
    public async Task<Guid> ValidateAndGetIdAsync(
        string deviceId,
        UserSignInAttemptType type,
        string code,
        Guid userId,
        string userName,
        CancellationToken ct)
    {
        var ip = httpContextDataSearcher.FindIp().GetValue();
        var userAgent = httpContextDataSearcher.FindUserAgent().GetValue();
        var codeHash = hashClient.Generate(code);

        var signInAttemptDto = await userSignInAttemptRepository.FindAsync(
            mode: SearchModeEnum.First,
            predicate: x
                => x.UserId == userId
                && x.DeviceId == deviceId
                && x.Type == type
                && x.Ip == ip
                && x.UserAgent == userAgent
                && x.SessionId == null,
            selector: x => new
            {
                x.Id,
                x.CreatedDate,
                x.CodeHash
            },
            sorter: x => x.OrderByDescending(y => y.CreatedDate),
            ct: ct);
        SignInAttemptIsInvalidException.ThrowWhenSignInAttemptNotExist(signInAttemptDto, userId, userName);
        CodeIsIncorrectException.ThrowWhenInvalid(signInAttemptDto.CodeHash == codeHash, userId, userName);

        var currentDateTime = dateTimeProvider.UtcNow();
        var validDateTimeOffset = currentDateTime - TimeSpan.FromMinutes(Consts.ValidTimeSpanToBeAuthorizedMin);
        SignInAttemptIsInvalidException.ThrowWhenSignInAttemptDontPassValidDateTime(signInAttemptDto.CreatedDate, validDateTimeOffset, userId, userName);

        return signInAttemptDto.Id;
    }
}
