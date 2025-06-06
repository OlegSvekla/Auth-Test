using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Commands.SignUps;

public sealed record SignUserUpCommand(
    string FirstName,
    string? Phone,
    string Email,
    bool? Simulacrum,
    string? HardcodedCode
    ) : IMediatrCreateCommand
{
    public Guid Id { get; set; }
}
