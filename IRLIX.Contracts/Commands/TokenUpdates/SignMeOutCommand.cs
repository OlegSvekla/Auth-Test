using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Commands.TokenUpdates;

public sealed record SignMeOutCommand(
    string RefreshToken,
    string DeviceId,
    bool? AllOpenSessions
    ) : IMediatrCommand;
