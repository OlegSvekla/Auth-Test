using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Commands.OtpConfirms;

public record ConfirmMeOtpViaEmailCommand(
    string Email,
    string DeviceId
    ) : IMediatrCommand;
