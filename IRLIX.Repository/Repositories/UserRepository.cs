using IRLIX.Core.Entities;
using IRLIX.Repository.Repositories.Common;
using IRLIX.Repository.Repository.Interfaces;

namespace IRLIX.Repository.Repositories;

public class UserRepository(GodContext dbContext)
    : Repository<UserEntity>(dbContext), IUserRepository
{
    //public async Task<IList<PlayerEntity>> GetPlayersWithNotifiesAsync(
    //    int pageSize,
    //    int pageIndex,
    //    CancellationToken ct)
    //    => await GetAllAsync(
    //            selector: e => new PlayerEntity
    //            {
    //                Id = e.Id,
    //                ChatId = e.ChatId,
    //                TelegramName = e.TelegramName,
    //                PlayerNotifies = e.PlayerNotifies,
    //            },
    //            amount: pageSize,
    //            offset: pageIndex * pageSize,
    //            sorter: query => query.OrderBy(player => player.Id),
    //            behavior: QueryTrackingBehavior.NoTracking,
    //            ct: ct);

    //public async Task<IList<PlayerEntity>> GetPlayersWithReferralsAsync(
    //    int pageSize,
    //    int pageIndex,
    //    CancellationToken ct)
    //    => await GetAllAsync(
    //            selector: e => new PlayerEntity
    //            {
    //                Id = e.Id,
    //                ChatId = e.ChatId,
    //                TelegramName = e.TelegramName,
    //                PlayerReferrals = new PlayerReferralsEntity
    //                {
    //                    Id = e.PlayerReferrals.Id,
    //                    Referrals = e.PlayerReferrals.Referrals,
    //                    InvitedByPlayerId = e.PlayerReferrals.InvitedByPlayerId,
    //                    IsConfirmedIfReferral = e.PlayerReferrals.IsConfirmedIfReferral,
    //                    IsFirstNotifyConfirmed = e.PlayerReferrals.IsFirstNotifyConfirmed,
    //                },
    //            },
    //            amount: pageSize,
    //            offset: pageIndex * pageSize,
    //            predicate: player => !player.PlayerReferrals.IsConfirmedIfReferral &&
    //                player.PlayerReferrals.InvitedByPlayerId != null &&
    //                player.PlayerAssets.FreedomPoints >= 500,
    //            sorter: query => query.OrderBy(player => player.Id),
    //            behavior: QueryTrackingBehavior.NoTracking,
    //            ct: ct);
}

