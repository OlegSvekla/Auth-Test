using IRLIX.Auth.Contracts.Commands.TokenUpdates;
using IRLIX.Auth.Web.Models.Rqs.TokenUpdates;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.TokenUpdates;

internal class UpdateMyAccessTokenByRefreshTokenBodyRqToCommandMapper
    : IMapper<UpdateMyAccessTokenByRefreshTokenBodyRq, UpdateMyAccessTokenByRefreshTokenCommand>
{
    public UpdateMyAccessTokenByRefreshTokenCommand Map(
        UpdateMyAccessTokenByRefreshTokenBodyRq input)
        => new UpdateMyAccessTokenByRefreshTokenCommand(
            RefreshToken: input.RefreshToken,
            DeviceId: input.DeviceId
            );
}
