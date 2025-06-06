using IRLIX.Context;

namespace IRLIX.Context;

/// <summary>
/// Data which purpose is to track request/action execution
/// and to store metadata
/// </summary>
public interface ICallContext
{
    /// <summary>
    /// Tracker id. Should always be unique for each request/action.
    /// </summary>
    Guid CorrelationId { get; }

    /// <summary>
    /// Collection with metadata, which works as header in http.
    /// </summary>
    IDictionary<string, object> Metadata { get; }   //TODO: set limits for dictionary size

    /// <summary>
    /// User's id who executed the request/action.
    /// </summary>
    UserClaims? UserClaims { get; }
}

/// <summary>
/// Data context which purpose is to track request/action execution
/// </summary>
/// <param name="CorrelationId">Tracker id. Should always be unique for each request/action.</param>
/// <param name="UserClaims">User's id who executed the request/action.</param>
/// <param name="Scope">Scope in which request/action should be executed.</param>
/// <param name="Metadata">Collection with metadata, which works as header in http.</param>
public sealed record CallContext(
    Guid CorrelationId,
    IDictionary<string, object> Metadata,
    UserClaims? UserClaims = null
    ) : ICallContext
{
    public override string ToString()
        => CorrelationId.ToString();
}
