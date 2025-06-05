using IRLIX.Core.Hashes;
using IRLIX.Core.Identity;
using IRLIX.Repository.Repository.Interfaces.Common;
using Microsoft.EntityFrameworkCore;

namespace IRLIX.BL.Shared.Modifiers.Updaters;

public interface ISignInAttemptByCodeUpdater
{
    Task UpdateAsync(
        Guid signInAttemptId,
        string code,
        CancellationToken ct);
}

internal class SignInAttemptByCodeUpdater(
    IHashClient hashClient,
    IRepository<SignInAttemptEntity> signInAttemptRepository,
    IUow uow
    ) : ISignInAttemptByCodeUpdater
{
    public async Task UpdateAsync(
        Guid signInAttemptId,
        string code,
        CancellationToken ct)
    {
        var signInAttempt = await signInAttemptRepository.GetByIdAsync(
            id: signInAttemptId,
            selector: x => new SignInAttemptEntity
            {
                Id = x.Id,
                CodeHash = x.CodeHash
            },
            behavior: QueryTrackingBehavior.TrackAll,
            ct: ct);

        var codeHash = hashClient.Generate(code);
        signInAttempt.CodeHash = codeHash;

        await signInAttemptRepository.UpdateAsync(signInAttempt, x => x.CodeHash, ct);
        await uow.CommitAsync(ct);
    }
}
