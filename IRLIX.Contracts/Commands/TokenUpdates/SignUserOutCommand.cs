using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Commands.TokenUpdates;

public sealed record SignUserOutCommand(
    Guid UserId,
    Guid SessionId,
    bool? AllOpenSessions
    ) : IMediatrCommand;
