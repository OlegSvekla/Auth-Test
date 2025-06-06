using IRLIX.Core.Attributes;
using IRLIX.Core.Exceptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IRLIX.BL.Exceptions.SignIns;

[HttpResponseStatusCode(Status400BadRequest)]
public class MultipleUsersFoundByEmailException(
    string email,
    Exception? innerEx = null
    ) : DomainException(
        message: $"Multiple users found with same '{email}' email",
        innerEx: innerEx)
{
    public override int Code => (int)ExCodes.MultipleUsersFoundByEmail;

    public static MultipleUsersFoundByEmailException CreateWhenMultiple(string email)
        => new MultipleUsersFoundByEmailException(email);
}
