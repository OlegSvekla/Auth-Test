using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Commands.TokenUpdates;

public sealed record UpdateMyAccessTokenByRefreshTokenCommand(
    string RefreshToken,
    string DeviceId
    ) : IMediatrCreateCommand
{
    public Guid Id { get; set; }
}
