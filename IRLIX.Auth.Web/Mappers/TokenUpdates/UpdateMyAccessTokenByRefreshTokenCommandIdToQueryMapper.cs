using IRLIX.Auth.Contracts.Queries.TokenUpdates;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.TokenUpdates;

internal class UpdateMyAccessTokenByRefreshTokenCommandIdToQueryMapper
    : IMapper<Guid, UpdateMyAccessTokenByRefreshTokenQuery>
{
    public UpdateMyAccessTokenByRefreshTokenQuery Map(
        Guid input)
        => new UpdateMyAccessTokenByRefreshTokenQuery(
            Id: input
            );
}
