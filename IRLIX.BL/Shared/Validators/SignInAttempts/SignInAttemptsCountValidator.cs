using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.BL.Shared.Lockouts;
using IRLIX.Core.Time;
using IRLIX.Ef.Repositories;

namespace IRLIX.BL.Shared.Modifiers.Validators.SignInAttempts;

public interface IAccessFailedCountValidator
{
    Task<int> ValidateAndGetAsync(
        Guid userId,
        string userName,
        CancellationToken ct);
}

internal class SignInAttemptsCountValidator(
    IRepository<SignInAttemptEntity> userSignInAttemptRepository,
    IDateTimeProvider dateTimeProvider,
    IUserLockoutSetter userLockoutSetter
    ) : IAccessFailedCountValidator
{
    public async Task<int> ValidateAndGetAsync(
        Guid userId,
        string userName,
        CancellationToken ct)
    {
        var currentDateTime = dateTimeProvider.UtcNow();
        var validDateTimeOffset = currentDateTime - TimeSpan.FromHours(Consts.SignInAttemptsValidTimeSpanHour);

        var dtos = await userSignInAttemptRepository.GetAllAsync(
            amount: Consts.LastSignInAttemptsCount,
            predicate: signInAttempt
                => signInAttempt.CreatedDate > validDateTimeOffset
                && signInAttempt.UserId == userId,
            sorter: attempts => attempts
                .OrderByDescending(signInAttempt => signInAttempt.CreatedDate),
            selector: signInAttempt => new { signInAttempt.SessionId },
            ct: ct);
        var signInAttempts = dtos
            .TakeWhile(x => x.SessionId == null)
            .Count();

        if (signInAttempts > Consts.AccessFailedIncAfterSignInAttemptsCount)
        {
            await userLockoutSetter.SetAccessFailedAndTryLockAsync(userId, userName, ct: ct);
        }

        return signInAttempts;
    }
}
