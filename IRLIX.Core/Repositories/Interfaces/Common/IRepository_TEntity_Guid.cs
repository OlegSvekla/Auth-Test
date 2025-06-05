using IRLIX.Core.Ef.Models.Enterfaces;

namespace IRLIX.Repository.Repository.Interfaces.Common;

public interface IRepository<TEntity>
    : IRepository<TEntity, Guid>
    where TEntity : class, IEntity;
