using IRLIX.Core.Interfaces.Mappers;
using IRLIX.Ef.Exceptions;
using IRLIX.Ef.Helpers;
using System.Linq.Expressions;

namespace IRLIX.Ef.Sorting;

public interface ISortingStringToExpressionMapper<T>
    : IMapper<string?, Func<IQueryable<T>, IOrderedQueryable<T>>?>
{
}

public class SortingStringToExpressionMapper<T>(
    ISortingQueryableByOperatorProvider<T> sortingQueryableByOperatorProvider,
    ISortingOrderedQueryableByOperatorProvider<T> sortingOrderedQueryableByOperatorProvider
    ) : ISortingStringToExpressionMapper<T>
{
    public Func<IQueryable<T>, IOrderedQueryable<T>>? Map(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        try
        {
            var predicate = InnerMap(input);
            return predicate;
        }
        catch (InvalidSortingOrFilteringDataException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw InvalidSortingOrFilteringDataException.CreateWhenUnknownEx(ex);
        }
    }

    private Func<IQueryable<T>, IOrderedQueryable<T>> InnerMap(string input)
    {
        var conditions = input.Split(Consts.ConditionsSeparator);
        InvalidSortingOrFilteringDataException.ThrowWhenConditionsAreEmpty(conditions);

        var firstCondition = conditions.First();
        var orderByFunc = BuildOrderByFunc(firstCondition);

        if (conditions.Length <= 1)
        {
            return orderByFunc;
        }

        var thenByFuncs = conditions[1..]
            .Select(BuildThenByFunc)
            .ToList();
        return query =>
        {
            var orderedQueryable = orderByFunc(query);
            thenByFuncs.ForEach(thenByFunc => orderedQueryable = thenByFunc(orderedQueryable));
            return orderedQueryable;
        };
    }

    private Func<IQueryable<T>, IOrderedQueryable<T>> BuildOrderByFunc(
        string condition)
    {
        var (lambda, @operator) = BuildLambdaOperatorTuple(condition);
        var orderByFunc = sortingQueryableByOperatorProvider.Provide(@operator, lambda);
        return orderByFunc;
    }

    private Func<IOrderedQueryable<T>, IOrderedQueryable<T>> BuildThenByFunc(
        string condition)
    {
        var (lambda, @operator) = BuildLambdaOperatorTuple(condition);
        var thenByFunc = sortingOrderedQueryableByOperatorProvider.Provide(@operator, lambda);
        return thenByFunc;
    }

    private static (Expression<Func<T, object>>, string) BuildLambdaOperatorTuple(
        string condition)
    {
        var parts = condition.Split(Consts.ExpressionSeparator);
        if (parts.Length != Consts.ExpressionPartsCount)
        {
            throw InvalidSortingOrFilteringDataException.CreateWhenExpressionPartsCountIsIncorrect(condition);
        }

        var (field, @operator) = (parts[0], parts[1]);

        var parameter = Expression.Parameter(typeof(T), Consts.ExpressionArgName);
        var property = ExpressionHelper.Property(parameter, field);
        var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);
        return (lambda, @operator);
    }
}
