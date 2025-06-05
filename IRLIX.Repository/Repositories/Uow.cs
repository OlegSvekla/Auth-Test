using IRLIX.Repository.Repository.Interfaces;
using IRLIX.Repository.Repository.Interfaces.Common;

namespace IRLIX.Repository.Repositories;

public class Uow : IUow
{
    private bool disposed = false;
    private readonly GodContext context;

    public Uow(GodContext context)
    {
        this.context = context;

        UserRepository = new UserRepository(context);
    }

    public IUserRepository UserRepository { get; private set; }

    public async Task CommitAsync(
        CancellationToken ct = default)
        => await context.SaveChangesAsync(ct);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }
}
