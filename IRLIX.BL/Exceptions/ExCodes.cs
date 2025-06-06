namespace IRLIX.BL.Exceptions;

/// <summary>
/// Exception codes. Min: 10 000 Max: 19 999
/// </summary>
public enum ExCodes
{
    None = 10000,
    UserWithSameEmailAlreadyExist,
    UserHasNotBeenCreated,
    CodeOrEmailAreIncorrect,
    CodeOrPhoneAreIncorrect,
    UserProvidedIncorrectOldEmail,
    UserProvidedIncorrectOldPhone,
    UserNotFoundByEmail,
    UserNotFoundByPhone,
    MultipleUsersFoundByEmail,
    MultipleUsersFoundByPhone
}
