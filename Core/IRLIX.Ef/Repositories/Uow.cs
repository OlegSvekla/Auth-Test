using IRLIX.Core.Exceptions.Helpers;
using IRLIX.Ef.Exceptions;
using Microsoft.EntityFrameworkCore.Storage;

namespace IRLIX.Ef.Repositories;

public interface IUow
    : IDisposable
{
    Task CommitAsync(
        CancellationToken ct = default);

    IExecutionStrategy CreateStrategy();
}

/// <summary>
/// Unit Of Work
/// </summary>
/// <typeparam name="TEfContext"></typeparam>
public class Uow(
    IEfContext context
    ) : IUow
{
    public async Task CommitAsync(
        CancellationToken ct = default)
    {
        try
        {
            await context.SaveChangesAsync(ct);
        }
        catch (Exception ex)
        {
            throw new DbSaveChangesException(ex);
        }
    }

    public IExecutionStrategy CreateStrategy()
    {
        var result = context.Database.CreateExecutionStrategy();
        return result;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        NullReferenceExceptionHelper.ThrowWhenNull(context);

        context.Dispose();
        context = default!;
    }
}
