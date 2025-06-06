using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Commands.Users;

public sealed record SetUserLockoutCommand(
    Guid UserId,
    DateTime LockoutEndDate,
    string? LockoutReason
    ) : IMediatrCommand;
