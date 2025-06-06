using IRLIX.Core.General;
using IRLIX.Core.Time;
using IRLIX.Ef.Identity.Models;
using IRLIX.Ef.Repositories;
using IRLIX.Web.Identity.Exceptions;
using IRLIX.Web.Identity.Lockouts.Models;
using Microsoft.EntityFrameworkCore;

namespace IRLIX.Web.Identity.Lockouts;

public interface ILockoutClient
{
    ValueTask ValidateOrResetAsync(
        Guid userId,
        CancellationToken ct);

    ValueTask ValidateOrResetAsync(
        Guid userId,
        string userName,
        LockoutDto lockout,
        CancellationToken ct);

    ValueTask SetLockoutAsync(
        Guid userId,
        string userName,
        LockoutDto lockout,
        CancellationToken ct);
}

internal class LockoutClient<TUser>(
    IAuthUserManager<TUser> userManager,
    IRepository<TUser> userRepository,
    IDateTimeProvider dateTimeProvider,
    IUow uow
    ) : ILockoutClient
    where TUser : EfIdentityUserEntity
{
    public async ValueTask ValidateOrResetAsync(
        Guid userId,
        CancellationToken ct)
    {
        var dto = await userRepository.GetByIdAsync(
            id: userId,
            selector: user => new
            {
                user.UserName,
                Lockout = new LockoutDto
                {
                    Enabled = user.LockoutEnabled,
                    EndDate = user.LockoutEnd,
                    Reason = user.LockoutReason,
                    CreatedDate = user.LockoutCreatedDate,
                    CreatedByUserId = user.LockoutCreatedByUserId
                }
            },
            ct: ct);

        await ValidateOrResetAsync(
            userId: userId,
            userName: dto.UserName.GetValue(),
            lockout: dto.Lockout,
            ct: ct);
    }

    public async ValueTask ValidateOrResetAsync(
        Guid userId,
        string userName,
        LockoutDto lockout,
        CancellationToken ct)
    {
        if (!lockout.EndDate.HasValue)
        {
            return;
        }

        var currentDateTime = dateTimeProvider.UtcNow();
        if (currentDateTime < lockout.EndDate.Value)
        {
            UserLockedOutException.ThrowIfLockoutEndDateFound(lockout);
        }

        var newLockout = LockoutDto.CreateDefault(lockout.Enabled);
        await SetLockoutAsync(userId, userName, newLockout, ct);
    }

    public async ValueTask SetLockoutAsync(
        Guid userId,
        string userName,
        LockoutDto lockout,
        CancellationToken ct)
    {
        if (!lockout.Enabled && lockout.EndDate == null)
        {
            var newLockout = LockoutDto.CreateDefault(lockout.Enabled);
            return;
        }

        await userManager.SetLockoutEndDateAsync(userName, lockout.EndDate, ct);

        var user = await userRepository.GetByIdAsync(
            id: userId,
            selector: x => x,
            behavior: QueryTrackingBehavior.TrackAll,
            ct: ct);

        user.LockoutReason = lockout.Reason;
        user.LockoutCreatedDate = lockout.CreatedDate;
        user.LockoutCreatedByUserId = lockout.CreatedByUserId;
        await userRepository.UpdateAsync(user, x => x.LockoutReason, ct);
        await userRepository.UpdateAsync(user, x => x.LockoutCreatedDate, ct);
        await userRepository.UpdateAsync(user, x => x.LockoutCreatedByUserId, ct);

        await uow.CommitAsync(ct);
    }
}
