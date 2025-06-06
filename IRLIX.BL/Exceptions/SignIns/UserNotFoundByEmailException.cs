using IRLIX.BL.Exceptions;
using IRLIX.Core.Attributes;
using IRLIX.Core.Exceptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ShuttleX.Auth.Exceptions.SignIns;

[HttpResponseStatusCode(Status404NotFound)]
public class UserNotFoundByEmailException(
    string email,
    Exception? innerEx = null
    ) : DomainException(
        message: $"User with '{email}' email address has not been registered yet",
        innerEx: innerEx)
{
    public override int Code => (int)ExCodes.UserNotFoundByEmail;

    public static UserNotFoundByEmailException CreateWhenNotFound(string email)
        => new UserNotFoundByEmailException(email);
}
