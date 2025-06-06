using IRLIX.Auth.Contracts.Commands.SignIns;
using IRLIX.Auth.Web.Models.Rqs.SignIns;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.SignIns;

internal class SignMeInViaEmailBodyRqToCommandMapper
    : IMapper<SignMeInViaEmailBodyRq, SignMeInViaEmailCommand>
{
    public SignMeInViaEmailCommand Map(
        SignMeInViaEmailBodyRq input)
        => new SignMeInViaEmailCommand(
            Email: input.Email,
            DeviceId: input.DeviceId
            );
}
