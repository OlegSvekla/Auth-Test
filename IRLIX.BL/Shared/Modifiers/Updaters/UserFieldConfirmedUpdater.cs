using IRLIX.Core.Entities;
using IRLIX.Core.Identity;

namespace IRLIX.BL.Shared.Modifiers.Updaters;

public interface IUserFieldConfirmedUpdater
{
    Task SetEmailConfirmedAsync(
        string userName,
        CancellationToken ct);

    Task SetPhoneConfirmedAsync(
        string userName,
        CancellationToken ct);

    // TODO: Deleted tracked user id after fixing issue with it
    Task SetAllPhoneUnconfirmedAsync(
        Guid trackedUserId,
        string phone,
        CancellationToken ct);
}

internal class UserFieldConfirmedUpdater(
    IAuthUserManager<UserEntity> userManager,
    IRepository<UserEntity> repository,
    IUow uow
    ) : IUserFieldConfirmedUpdater
{
    public async Task SetEmailConfirmedAsync(
        string userName,
        CancellationToken ct)
        => await userManager.ConfirmEmailAsync(userName, ct);

    public async Task SetPhoneConfirmedAsync(
        string userName,
        CancellationToken ct)
        => await userManager.ConfirmPhoneAsync(userName, ct);

    public async Task SetAllPhoneUnconfirmedAsync(
        Guid trackedUserId,
        string phone,
        CancellationToken ct)
    {
        // TODO: This get all doesn't tracking any entities even with behavior: QueryTrackingBehavior.TrackAll
        var samePhoneUsers = await repository.GetAllAsync(
            predicate: user
                => user.PhoneNumber == phone
                && user.PhoneNumberConfirmed
                && user.Id != trackedUserId,
            selector: user => new UserEntity
            {
                Id = user.Id,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed
            },
            ct: ct);

        foreach (var user in samePhoneUsers)
        {
            // TODO: Fix getting user from bd each times
            var trackedUser = await repository.GetByIdAsync(id: user.Id, selector: u => u, ct: ct);
            trackedUser.PhoneNumberConfirmed = false;
            await repository.UpdateAsync(trackedUser, u => u.PhoneNumberConfirmed, ct);
        }

        await uow.CommitAsync(ct);
    }
}
