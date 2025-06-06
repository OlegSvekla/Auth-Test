using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.Auth.Contracts.Queries.Users;
using IRLIX.Core.General;
using IRLIX.Ef.Repositories;
using IRLIX.Mq.Local.MediatR.Handlers;

namespace IRLIX.BL.Handlers.Queries;

internal class GetUsersQueryHandler(
    IRepository<UserEntity> userRepository
    ) : MediatrQueryHandler<GetUsersQuery, IReadOnlyCollection<GetUsersQueryRs>>
{
    public override async ValueTask<IReadOnlyCollection<GetUsersQueryRs>> HandleAsync(
        GetUsersQuery query,
        CancellationToken ct)
    {
        var dtos = await userRepository.GetAllAsync(
            selector: user => new
            {
                UserId = user.Id,
                user.CreatedDate,
                user.CreatedByUserId,
                user.UpdatedDate,
                user.UpdatedByUserId,
                user.PhoneNumber,
                user.PhoneNumberConfirmed,
                user.Email,
                user.EmailConfirmed,
                user.LockoutCreatedDate,
                user.LockoutCreatedByUserId,
                user.AccessFailedCount,
                user.LockoutEnd,
                UserRoleNames = user.UserRoles
                    .Select(role => role.Role.Name.GetValue())
                    .ToArray()
            },
            amount: query.Amount,
            offset: query.Offset,
            ct: ct);

        var rs = dtos
            .Select(dto => new GetUsersQueryRs(
                Id: dto.UserId,
                CreatedDate: dto.CreatedDate,
                CreatedByUserId: dto.CreatedByUserId,
                UpdatedDate: dto.UpdatedDate,
                UpdatedByUserId: dto.UpdatedByUserId,
                Phone: dto.PhoneNumber?.GetValue(),
                IsPhoneVerified: dto.PhoneNumberConfirmed,
                Email: dto.Email.GetValue(),
                IsEmailVerified: dto.EmailConfirmed,
                Lockout: new LockoutQueryRs(
                    CreatedDate: dto.LockoutCreatedDate,
                    CreatedByUserId: dto.LockoutCreatedByUserId,
                    AttempsCount: dto.AccessFailedCount,
                    EndDate: dto.LockoutEnd),
                RoleNames: dto.UserRoleNames
                )
            )
            .ToArray();
        return rs;
    }
}
