using IRLIX.Core.General;
using IRLIX.Ef.Configs;
using IRLIX.Ef.Setup.Soft.Attributes;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace IRLIX.Ef.Setup.Soft;

public interface ISoftPropertiesCreator
{
    ValueTask OnModelCreating(
        ModelBuilder modelBuilder);
}

public class SoftPropertiesCreator(
    IOptions<DbConfig> options
    ) : ISoftPropertiesCreator
{
    private readonly DbConfig config = options.Value;

    public ValueTask OnModelCreating(ModelBuilder modelBuilder)
    {
        CreateAllSoftDeletedProperties(modelBuilder);
        return ValueTask.CompletedTask;
    }

    private void CreateAllSoftDeletedProperties(ModelBuilder modelBuilder)
    {
        if (!config.SetSoftDeleteByDefault)
        {
            return;
        }

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (entityType.ClrType.HasAttribute<NonSoftDeleteAttribute>()
                || entityType.IsOwned()
                || entityType.IsKeyless
                || entityType.FindPrimaryKey() == null
                || entityType.ClrType == typeof(Dictionary<string, object>)
                || entityType.BaseType != null)
            {
                continue;
            }

            entityType.AddProperty(Consts.SoftDeletePropertyName, typeof(DateTimeOffset?));

            var parameter = Expression.Parameter(entityType.ClrType);
            var propertyMethodInfo = typeof(EF)
                .GetMethod("Property")
                ?.MakeGenericMethod(typeof(DateTimeOffset?)) ?? throw new Exception("Property not found");
            var deletedDateProperty = Expression.Call(
                method: propertyMethodInfo,
                arg0: parameter,
                arg1: Expression.Constant(Consts.SoftDeletePropertyName));
            var compareExpression = Expression.MakeBinary(
                binaryType: ExpressionType.Equal,
                left: deletedDateProperty,
                right: Expression.Constant(null));
            var lambda = Expression.Lambda(
                body: compareExpression,
                parameters: parameter);
            modelBuilder.Entity(entityType.ClrType)
                .HasQueryFilter(lambda);
        }
    }
}
