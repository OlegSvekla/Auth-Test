using IRLIX.Core.Exceptions;

namespace IRLIX.Ef.Exceptions;

public class DbSaveChangesException(
    Exception? innerEx = null
    ) : DomainException(ErrorMessage, innerEx)
{
    private const string ErrorMessage = "Exception during save db changes";
    public override int Code => (int)ExCodes.DbSaveChanges;
}
