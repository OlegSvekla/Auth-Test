using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Commands.OtpVerifies;

public record VerifyConfirmByMeViaEmailCommand(
    string Email,
    string Code,
    string DeviceId
    ) : IMediatrCreateCommand
{
    public Guid Id { get; set; }
}
