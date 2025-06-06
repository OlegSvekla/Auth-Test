using IRLIX.Core.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace IRLIX.Web.Identity.Exceptions;

public class BadIdentityResultException(
    IdentityResult identityResult,
    Exception? innerEx = null
    ) : DomainException(
        message: ErrorMessage,
        innerEx: innerEx)
{
    private const string ErrorMessage = "User has not been processed correctly. Please try again later";
    public override int Code => (int)ExCodes.BadIdentityResult;
    public IdentityResult IdentityResult { get; } = identityResult;

    public static void ThrowWhenNotSuccess(IdentityResult identityResult)
    {
        if (!identityResult.Succeeded)
        {
            throw new BadIdentityResultException(identityResult);
        }
    }
}
