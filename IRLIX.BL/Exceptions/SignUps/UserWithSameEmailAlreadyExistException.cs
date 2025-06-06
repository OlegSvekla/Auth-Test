using IRLIX.Core.Attributes;
using IRLIX.Core.Exceptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IRLIX.BL.Exceptions.SignUps;

[HttpResponseStatusCode(Status400BadRequest)]
public class UserWithSameEmailAlreadyExistException(
    string email,
    Exception? innerEx = null
    ) : DomainException(
        message: $"User with '{email}' email address already has been registered",
        innerEx: innerEx)
{
    public override int Code => (int)ExCodes.UserWithSameEmailAlreadyExist;

    public static void ThrowWhenUserExist(
        bool existUser,
        string email)
    {
        if (existUser)
        {
            throw new UserWithSameEmailAlreadyExistException(email);
        }
    }
}
