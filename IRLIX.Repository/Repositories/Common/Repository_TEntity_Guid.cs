using IRLIX.Core.Ef.Models.Enterfaces;
using IRLIX.Repository.Repository.Interfaces.Common;

namespace IRLIX.Repository.Repositories.Common;

public class Repository<TEntity>(
    GodContext context
    ) : Repository<TEntity, Guid>(
        context),
        IRepository<TEntity>
    where TEntity : class, IEntity, new();
