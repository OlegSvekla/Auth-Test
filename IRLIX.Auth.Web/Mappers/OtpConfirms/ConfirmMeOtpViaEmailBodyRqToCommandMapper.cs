using IRLIX.Auth.Contracts.Commands.OtpConfirms;
using IRLIX.Auth.Web.Models.Rqs.OtpConfirms;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.OtpConfirms;

public class ConfirmMeOtpViaEmailBodyRqToCommandMapper
    : IMapper<ConfirmMeOtpViaEmailBodyRq, ConfirmMeOtpViaEmailCommand>
{
    public ConfirmMeOtpViaEmailCommand Map(
        ConfirmMeOtpViaEmailBodyRq input)
        => new ConfirmMeOtpViaEmailCommand(
            input.Email,
            input.DeviceId
            );
}
