using IRLIX.Auth.Contracts.Queries.Sessions;
using IRLIX.Auth.Web.Models.Rss.Sessions;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.Sessions;

internal class SessionQueryRssToRssMapper
    : IMapper<IReadOnlyCollection<SessionQueryRs>, IReadOnlyCollection<SessionRs>>
{
    public IReadOnlyCollection<SessionRs> Map(
        IReadOnlyCollection<SessionQueryRs> input)
        => input
            .Select(x => new SessionRs(
                Id: x.Id,
                CreatedDate: x.CreatedDate,
                Ip: x.Ip,
                UserAgent: x.UserAgent,
                DeviceId: x.DeviceId
                ))
            .ToArray();
}
