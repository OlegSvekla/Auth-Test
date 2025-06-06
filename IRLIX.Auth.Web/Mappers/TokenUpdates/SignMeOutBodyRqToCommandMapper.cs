using IRLIX.Auth.Contracts.Commands.TokenUpdates;
using IRLIX.Auth.Web.Models.Rqs.TokenUpdates;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.TokenUpdates;

internal class SignMeOutBodyRqToCommandMapper
    : IMapper<SignMeOutBodyRq, SignMeOutCommand>
{
    public SignMeOutCommand Map(
        SignMeOutBodyRq input)
        => new SignMeOutCommand(
            RefreshToken: input.RefreshToken,
            DeviceId: input.DeviceId,
            AllOpenSessions: input.AllOpenSessions
            );
}
