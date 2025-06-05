using IRLIX.Core.Entities;
using IRLIX.Core.IRLIX.Web.Identity.Lockouts.Models;
using IRLIX.Repository.Enums;
using System.Linq.Expressions;

namespace IRLIX.BL.Shared.Modifiers.Searchers;

public class UserWithEmail
{
    public Guid UserId { get; set; }

    public LockoutDto Lockout { get; set; } = default!;

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? HardcodedCode { get; set; }
}

public interface IUserWithEmailSearcher
{
    Task<UserWithEmail> ValidateAndGetAsync(
        string email,
        CancellationToken ct);

    Task<UserWithEmail> ValidateAndGetAsync(
        Guid userId,
        string email,
        CancellationToken ct);
}

internal class UserWithEmailSearcher(
    IRepository<UserEntity> userRepository
    ) : IUserWithEmailSearcher
{
    public async Task<UserWithEmail> ValidateAndGetAsync(
        string email,
        CancellationToken ct)
    {
        //TODO: implement ip validator to block in case of multiple calls

        var userByEmailDtos = await userRepository.GetAllAsync(
            predicate: user
                => user.Email == email,
            selector: UserWithEmailSelector,
            ct: ct);
        if (userByEmailDtos.IsOneItemCollection())
        {
            return userByEmailDtos.Single();
        }

        if (!userByEmailDtos.Any())
        {
            throw UserNotFoundByEmailException.CreateWhenNotFound(email);
        }

        throw MultipleUsersFoundByEmailException.CreateWhenMultiple(email);
    }

    public async Task<UserWithEmail> ValidateAndGetAsync(
        Guid userId,
        string email,
        CancellationToken ct)
    {
        var userByEmailDto = await userRepository.FindAsync(
            mode: SearchModeEnum.Single,
            predicate: user
                => user.Id == userId
                && user.Email == email,
            selector: UserWithEmailSelector,
            ct: ct);
        return userByEmailDto
            ?? throw UserNotFoundByEmailException.CreateWhenNotFound(email);
    }

    private static Expression<Func<UserEntity, UserWithEmail>> UserWithEmailSelector
        => user => new UserWithEmail
        {
            UserId = user.Id,
            Lockout = new LockoutDto
            {
                Enabled = user.LockoutEnabled,
                EndDate = user.LockoutEnd,
                Reason = user.LockoutReason,
                CreatedDate = user.LockoutCreatedDate,
                CreatedByUserId = user.LockoutCreatedByUserId
            },
            UserName = user.UserName,
            Email = user.Email,
            HardcodedCode = user.HardcodedCode
        };
}
