namespace IRLIX.Auth.Contracts.Queries.Sessions;

public sealed record SessionQueryRs(
    Guid Id,
    DateTimeOffset CreatedDate,
    string Ip,
    string UserAgent,
    string DeviceId
    );
