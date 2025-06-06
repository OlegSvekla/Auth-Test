using IRLIX.Auth.Contracts.Queries.VerifyCodes;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.VerifyCodes;

internal class VerifyCodeByMeViaEmailCommandIdToQueryMapper
    : IMapper<Guid, VerifyCodeByMeViaEmailQuery>
{
    public VerifyCodeByMeViaEmailQuery Map(
        Guid input)
        => new VerifyCodeByMeViaEmailQuery(
            Id: input
            );
}
