using IRLIX.Auth.Contracts.Commands.OtpVerifies;
using IRLIX.Auth.Web.Models.Rqs.OtpVerifies;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.OtpVerifies;

public class VerifyConfirmByMeViaEmailBodyRqToCommandMapper
    : IMapper<VerifyConfirmByMeViaEmailBodyRq, VerifyConfirmByMeViaEmailCommand>
{
    public VerifyConfirmByMeViaEmailCommand Map(VerifyConfirmByMeViaEmailBodyRq input)
        => new VerifyConfirmByMeViaEmailCommand(
            input.Email,
            input.Code,
            input.DeviceId
            );
}
