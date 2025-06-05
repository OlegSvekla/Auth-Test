using IRLIX.Core.Core.General;
using IRLIX.Core.Identity.Models;

namespace IRLIX.Core.Context;

public interface ICallContextInitializer
{
    /// <summary>
    /// Set call context as part of previous chain of processes
    /// </summary>
    /// <param name="callContext"></param>
    void Init(ICallContext? callContext = null);

    /// <summary>
    /// Initialize user claims when user detected and authorized
    /// </summary>
    /// <param name="userClaims"></param>
    ICallContext InitClaims(UserClaims userClaims);
}

/// <summary>
/// Call context provider.
/// Important: should be with lifetime only for scope of requests,
/// jobs or other scoped services
/// </summary>
public interface ICallContextProvider
{
    /// <summary>
    /// Provide call context
    /// </summary>
    /// <returns></returns>
    ICallContext Get();

    /// <summary>
    /// Provide user claims from call context
    /// </summary>
    /// <returns></returns>
    UserClaims GetUserClaims();
}

/// <summary>
/// Call context storage.
/// Important: should be with lifetime only for scope of requests,
/// jobs or other scoped services
/// </summary>
public sealed class CallContextStorage
    : ICallContextInitializer,
    ICallContextProvider
{
    private ICallContext? callContext;

    public ICallContext Get()
        => callContext.GetValue();

    public UserClaims GetUserClaims()
        => callContext.GetValue().UserClaims.GetValue();

    public void Init(ICallContext? callContext = null)
        => this.callContext = callContext
            ?? new CallContext(
                CorrelationId: Guid.NewGuid(),
                Metadata: new Dictionary<string, object>()
                );

    public ICallContext InitClaims(UserClaims userClaims)
    {
        var originalContext = callContext.GetValue();

        callContext = new CallContext(
            CorrelationId: originalContext.CorrelationId,
            Metadata: originalContext.Metadata,
            UserClaims: userClaims
            );

        return callContext;
    }
}
