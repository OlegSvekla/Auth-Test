using IRLIX.Core.Entities;

namespace IRLIX.BL.Shared.Modifiers.Validators.Users;

public interface IUserWithSameEmailExistValidator
{
    Task ValidateAsync(
        string email,
        CancellationToken ct);
}

internal sealed class UserWithSameEmailExistValidator(
    IRepository<UserEntity> repository
    ) : IUserWithSameEmailExistValidator
{
    public async Task ValidateAsync(
        string email,
        CancellationToken ct)
    {
        var existUser = await repository.ExistByPropertyAsync(
            predicate: user => user.Email == email,
            ct: ct);

        UserWithSameEmailAlreadyExistException.ThrowWhenUserExist(existUser, email);
    }
}
