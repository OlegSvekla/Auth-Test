using IRLIX.Auth.Contracts.Queries;
using IRLIX.Auth.Web.Models.Rss;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers;

internal class AuthTokensQueryRsToRsMapper
    : IMapper<AuthTokensQueryRs, AuthTokensRs>
{
    public AuthTokensRs Map(
        AuthTokensQueryRs value)
        => new AuthTokensRs(
            AccessToken: value.AccessToken,
            RefreshToken: value.RefreshToken,
            ExpiresAt: value.ExpiresAt
            );
}
