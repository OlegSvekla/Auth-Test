namespace IRLIX.Repository.Repository.Interfaces.Common;

public interface IUow
    : IDisposable
{
    Task CommitAsync(
        CancellationToken ct = default);

    IUserRepository UserRepository { get; }
}
