using IRLIX.Core.Entities;
using IRLIX.Repository.Repository.Interfaces.Common;

namespace IRLIX.Repository.Repository.Interfaces;

public interface IUserRepository : IRepository<UserEntity>
{
    //public Task<IList<PlayerEntity>> GetPlayersWithNotifiesAsync(
    //    int pageSize,
    //    int pageIndex,
    //    CancellationToken ct);

    //public Task<IList<PlayerEntity>> GetPlayersWithReferralsAsync(
    //    int pageSize,
    //    int pageIndex,
    //    CancellationToken ct);
}
