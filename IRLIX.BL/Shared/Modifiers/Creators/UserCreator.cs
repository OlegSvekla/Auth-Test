using IRLIX.Core.Context;
using IRLIX.Core.Entities;
using IRLIX.Core.Identity;

namespace IRLIX.BL.Shared.Modifiers.Creators;

public interface IUserCreator
{
    Task<UserEntity> CreateAsync(
        string phone,
        string email,
        CancellationToken ct);

    Task<UserEntity> CreateByAdminAsync(
        string? phone,
        string email,
        bool? simulacrum,
        string? hardcodedCode,
        CancellationToken ct);
}

internal sealed class UserCreator(
    IAuthUserManager<UserEntity> userManager,
    ICallContextProvider callContextProvider
    ) : IUserCreator
{
    public async Task<UserEntity> CreateAsync(
        string phone,
        string email,
        CancellationToken ct)
    {
        var userName = Guid.NewGuid().ToString();

        var createdUser = new UserEntity
        {
            UserName = userName,
            NormalizedUserName = userName.ToUpperInvariant(),
            SecurityStamp = Guid.NewGuid().ToString(),
            PhoneNumber = phone.ToLowerInvariant(),
            Email = email.ToLowerInvariant(),
            NormalizedEmail = email.ToUpperInvariant(),

        };

        createdUser = await userManager.CreateAsync(createdUser, ct);
        return createdUser;
    }

    public async Task<UserEntity> CreateByAdminAsync(
        string? phone,
        string email,
        bool? simulacrum,
        string? hardcodedCode,
        CancellationToken ct)
    {
        var userName = Guid.NewGuid().ToString();

        var createdUser = new UserEntity
        {
            UserName = userName,
            NormalizedUserName = userName.ToUpperInvariant(),
            SecurityStamp = Guid.NewGuid().ToString(),
            PhoneNumber = phone?.ToLowerInvariant(),
            PhoneNumberConfirmed = !string.IsNullOrEmpty(hardcodedCode),
            Email = email.ToLowerInvariant(),
            NormalizedEmail = email.ToUpperInvariant(),
            EmailConfirmed = !string.IsNullOrEmpty(hardcodedCode),
            Simulacrum = simulacrum,
            HardcodedCode = hardcodedCode,
            CreatedByUserId = callContextProvider.GetUserClaims().UserId
        };

        createdUser = await userManager.CreateAsync(createdUser, ct);
        return createdUser;
    }
}
