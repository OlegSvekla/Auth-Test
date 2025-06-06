using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Commands.VerifyCodes;

public sealed record VerifyCodeByMeViaEmailCommand(
    string Email,
    string Code,
    string DeviceId
    ) : IMediatrCreateCommand
{
    public Guid Id { get; set; }
}
