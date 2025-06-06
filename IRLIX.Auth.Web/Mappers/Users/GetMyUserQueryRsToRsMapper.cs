using IRLIX.Auth.Contracts.Queries.Users;
using IRLIX.Auth.Web.Models.Rss.Users;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.Users;

public class GetMyUserQueryRsToRsMapper
    : IMapper<GetMyUserQueryRs, GetMyUserRs>
{
    public GetMyUserRs Map(GetMyUserQueryRs input)
        => new GetMyUserRs(
            Phone: input.Phone,
            IsPhoneVerified: input.IsPhoneVerified,
            Email: input.Email,
            IsEmailVerified: input.IsEmailVerified
            );
}
