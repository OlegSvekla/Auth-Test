using IRLIX.Auth.Contracts.Queries.Sessions;
using IRLIX.Auth.Web.Models.Rqs.Sessions;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.Sessions;

internal class GetUserSessionsRqToQueryMapper
    : IMapper<GetUserSessionsRq, GetUserSessionsQuery>
{
    public GetUserSessionsQuery Map(
        GetUserSessionsRq input)
        => new GetUserSessionsQuery(
            UserId: input.UserId,
            Amount: input.QueryRq.Amount,
            Offset: input.QueryRq.Offset,
            SortBy: input.QueryRq.SortBy,
            FilterBy: input.QueryRq.FilterBy,
            IncludeDeleted: input.QueryRq.IncludeDeleted
            );
}
