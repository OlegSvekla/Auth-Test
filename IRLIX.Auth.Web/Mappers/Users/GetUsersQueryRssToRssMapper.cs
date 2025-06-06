using IRLIX.Auth.Contracts.Queries.Users;
using IRLIX.Auth.Web.Models.Rss.Users;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.Users;

internal class GetUsersQueryRssToRssMapper
    : IMapper<IReadOnlyCollection<GetUsersQueryRs>, IReadOnlyCollection<GetUsersRs>>
{
    public IReadOnlyCollection<GetUsersRs> Map(
        IReadOnlyCollection<GetUsersQueryRs> input)
        => input
            .Select(x => new GetUsersRs(
                Id: x.Id,
                CreatedDate: x.CreatedDate,
                CreatedByUserId: x.CreatedByUserId,
                UpdatedDate: x.UpdatedDate,
                UpdatedByUserId: x.UpdatedByUserId,
                Phone: x.Phone,
                IsPhoneVerified: x.IsPhoneVerified,
                Email: x.Email,
                IsEmailVerified: x.IsEmailVerified,
                Lockout: new LockoutRs(
                    CreatedDate: x.Lockout.CreatedDate,
                    CreatedByUserId: x.Lockout.CreatedByUserId,
                    AttempsCount: x.Lockout.AttempsCount,
                    EndDate: x.Lockout.EndDate
                    ),
                RoleNames: x.RoleNames
                ))
            .ToArray();
}
