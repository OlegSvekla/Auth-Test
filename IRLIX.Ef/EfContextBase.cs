using IRLIX.Ef.Setup;
using IRLIX.Ef.Setup.Soft;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using IRLIX.Core.General;

namespace IRLIX.Ef;

public interface IEfContext : IDisposable
{
    DatabaseFacade Database { get; }

    ChangeTracker ChangeTracker { get; }

    ValueTask InitAsync(CancellationToken ct);

    Task<int> SaveChangesAsync(CancellationToken ct = default);

    Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken ct = default);

    DbSet<TEntity> Set<TEntity>()
        where TEntity : class;

    EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        where TEntity : class;
}

public abstract class EfContextBase(
    DbContextOptions options,
    IDbConnector connector,
    IDbSeeder seeder,
    ISoftPropertiesUpdater softUpdater,
    ISoftPropertiesCreator softCreator
    ) : DbContext(options),
        IEfContext
{
    public async virtual ValueTask InitAsync(
        CancellationToken ct)
    {
        if (!Database.IsRelational())
        {
            return;
        }

        await Database.MigrateAsync(ct);
    }

    public override int SaveChanges()
    {
        softUpdater.OnSaveChangesAsync(ChangeTracker).AwaitSync();
        var result = base.SaveChanges();
        StopTracking();
        return result;
    }

    public override async Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken ct = default)
    {
        await softUpdater.OnSaveChangesAsync(ChangeTracker);
        var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, ct);
        StopTracking();
        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        softCreator.OnModelCreating(builder).AwaitSync();
        connector.ConnectAsync(builder).AwaitSync();
        seeder.SeedAsync(builder).AwaitSync();
    }

    private void StopTracking()
        => ChangeTracker.Clear();
}
