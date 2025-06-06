using IRLIX.Auth.Contracts.Commands.SignUps;
using IRLIX.Auth.Web.Models.Rqs.SignUps;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.SignUps;

internal class SignMeUpBodyRqToCommandMapper
    : IMapper<SignMeUpBodyRq, SignMeUpCommand>
{
    public SignMeUpCommand Map(
        SignMeUpBodyRq input)
        => new SignMeUpCommand(
            FirstName: input.FirstName,
            Phone: input.Phone,
            Email: input.Email
            );
};
