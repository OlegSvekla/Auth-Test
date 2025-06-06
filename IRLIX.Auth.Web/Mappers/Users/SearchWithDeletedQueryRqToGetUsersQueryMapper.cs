using IRLIX.Auth.Contracts.Queries.Users;
using IRLIX.Core.Interfaces.Mappers;
using IRLIX.Web.Models.Rqs;

namespace IRLIX.Auth.Web.Mappers.Users;

internal class SearchWithDeletedQueryRqToGetUsersQueryMapper
    : IMapper<SearchWithDeletedQueryRq, GetUsersQuery>
{
    public GetUsersQuery Map(
        SearchWithDeletedQueryRq input)
        => new GetUsersQuery(
           Amount: input.Amount,
           Offset: input.Offset,
           SortBy: input.SortBy,
           FilterBy: input.FilterBy,
           IncludeDeleted: input.IncludeDeleted);
}
