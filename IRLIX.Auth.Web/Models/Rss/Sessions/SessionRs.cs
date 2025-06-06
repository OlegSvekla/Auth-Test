namespace IRLIX.Auth.Web.Models.Rss.Sessions;

public sealed record SessionRs(
    Guid Id,
    DateTimeOffset CreatedDate,
    string Ip,
    string UserAgent,
    string DeviceId
    );
