using IRLIX.Auth.Contracts.Commands.VerifyCodes;
using IRLIX.Auth.Web.Models.Rqs.VerifyCodes;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.VerifyCodes;

internal class VerifyCodeByMeViaEmailBodyRqToCommandMapper
    : IMapper<VerifyCodeByMeViaEmailBodyRq, VerifyCodeByMeViaEmailCommand>
{
    public VerifyCodeByMeViaEmailCommand Map(
        VerifyCodeByMeViaEmailBodyRq input)
        => new VerifyCodeByMeViaEmailCommand(
            Email: input.Email,
            Code: input.Code,
            DeviceId: input.DeviceId
            );
}
