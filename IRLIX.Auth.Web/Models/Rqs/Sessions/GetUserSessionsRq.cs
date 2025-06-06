using IRLIX.Web.Models.Rqs;

namespace IRLIX.Auth.Web.Models.Rqs.Sessions;

public sealed record GetUserSessionsRq(
    Guid UserId,
    SearchWithDeletedQueryRq QueryRq
    );
