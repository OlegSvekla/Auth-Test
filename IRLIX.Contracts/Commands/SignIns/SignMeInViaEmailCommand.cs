using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Contracts.Commands.SignIns;

public sealed record SignMeInViaEmailCommand(
    string Email,
    string DeviceId
    ) : IMediatrCommand;
