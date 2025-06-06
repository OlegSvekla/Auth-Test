using IRLIX.Auth.Contracts.Commands.Users;
using IRLIX.Auth.Web.Models.Rqs.Users;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Auth.Web.Mappers.Users;

internal class SetUserLockoutRqToCommandMapper
    : IMapper<SetUserLockoutRq, SetUserLockoutCommand>
{
    public SetUserLockoutCommand Map(
        SetUserLockoutRq input)
        => new SetUserLockoutCommand(
            UserId: input.UserId,
            LockoutEndDate: input.BodyRq.LockoutEndDate,
            LockoutReason: input.BodyRq.LockoutReason
            );
}
