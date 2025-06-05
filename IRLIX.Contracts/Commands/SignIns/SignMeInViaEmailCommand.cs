using IRLIX.Core.Mq.Local.MediatR;

namespace IRLIX.Contracts.Commands.SignIns;

public sealed record SignMeInViaEmailCommand(
    string Email,
    string DeviceId
    ) : IMediatrCommand;
