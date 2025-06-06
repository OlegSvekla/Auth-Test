using IRLIX.Core.Attributes;
using IRLIX.Core.Exceptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IRLIX.BL.Exceptions.VerifyCodes;

[HttpResponseStatusCode(Status400BadRequest)]
public class CodeIsIncorrectException(
    Guid? userId = null,
    string? userName = null,
    Exception? innerEx = null
    ) : DomainException(
        message: ErrorMessage,
        innerEx: innerEx)
{
    private const string ErrorMessage = "Сode is incorrect";
    public override int Code => (int)ExCodes.CodeOrEmailAreIncorrect;
    public string? UserName { get; } = userName;
    public Guid? UserId { get; } = userId;

    public static void ThrowWhenInvalid(
        bool valid,
        Guid userId,
        string userName)
    {
        if (!valid)
        {
            throw new CodeIsIncorrectException(userId, userName);
        }
    }
}
