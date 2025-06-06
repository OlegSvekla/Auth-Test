using IRLIX.Ef.Models.Interfaces;

namespace IRLIX.Ef.Repositories;

public interface IRepository<TEntity>
    : IRepository<TEntity, Guid>
    where TEntity : class, IEntity;

public class Repository<TEntity>(
    IEfContext context
    ) : Repository<TEntity, Guid>(
        context),
        IRepository<TEntity>
    where TEntity : class, IEntity, new();
