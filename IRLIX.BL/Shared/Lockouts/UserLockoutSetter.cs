using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.Core.Time;
using IRLIX.Web.Identity;
using IRLIX.Web.Identity.Exceptions;
using IRLIX.Web.Identity.Lockouts;
using IRLIX.Web.Identity.Lockouts.Models;

namespace IRLIX.BL.Shared.Lockouts;

public interface IUserLockoutSetter
{
    ValueTask TrySetAccessFailedAndTryLockAsync(
        Guid? userId,
        string? userName,
        Guid? lockoutCreatedByUserId = null,
        string lockoutReason = Consts.LockoutSystemReason,
        CancellationToken ct = default);

    ValueTask SetAccessFailedAndTryLockAsync(
        Guid userId,
        string userName,
        Guid? lockoutCreatedByUserId = null,
        string lockoutReason = Consts.LockoutSystemReason,
        CancellationToken ct = default);
}

internal class UserLockoutSetter(
    IAuthUserManager<UserEntity> userManager,
    ILockoutClient lockoutClient,
    IDateTimeProvider dateTimeProvider
    ) : IUserLockoutSetter
{
    public async ValueTask TrySetAccessFailedAndTryLockAsync(
        Guid? userId,
        string? userName,
        Guid? lockoutCreatedByUserId = null,
        string lockoutReason = Consts.LockoutSystemReason,
        CancellationToken ct = default)
    {
        if (userId.HasValue && userName != null)
        {
            await SetAccessFailedAndTryLockAsync(userId.Value, userName, ct: ct);
        }
    }

    public async ValueTask SetAccessFailedAndTryLockAsync(
        Guid userId,
        string userName,
        Guid? lockoutCreatedByUserId = null,
        string lockoutReason = Consts.LockoutSystemReason,
        CancellationToken ct = default)
    {
        var accessFailedCount = await userManager.AccessFailedAsync(userName, ct);

        var needToLock = Consts.LockoutAttemptToDurationDict.TryGetValue(accessFailedCount, out var lockTimeSpan);
        if (!needToLock)
        {
            return;
        }

        var lockoutEnabled = await userManager.GetLockoutEnabledAsync(userName, ct);
        var currentDateTime = dateTimeProvider.UtcNow();
        var lockoutEndDate = currentDateTime.Add(lockTimeSpan);

        var lockout = new LockoutDto
        {
            Enabled = lockoutEnabled,
            EndDate = lockoutEndDate,
            Reason = lockoutReason,
            CreatedDate = currentDateTime,
            CreatedByUserId = lockoutCreatedByUserId
        };
        await lockoutClient.SetLockoutAsync(userId, userName, lockout, ct);

        UserLockedOutException.ThrowIfLockoutEndDateFound(lockout);
    }
}
