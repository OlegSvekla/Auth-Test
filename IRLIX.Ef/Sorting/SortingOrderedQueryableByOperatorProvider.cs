using IRLIX.Ef.Exceptions;
using System.Linq.Expressions;

namespace IRLIX.Ef.Sorting;

public interface ISortingOrderedQueryableByOperatorProvider<T>
{
    Func<IOrderedQueryable<T>, IOrderedQueryable<T>> Provide(
        string @operator,
        Expression<Func<T, object>> lambda);
}

public class SortingOrderedQueryableByOperatorProvider<T> : ISortingOrderedQueryableByOperatorProvider<T>
{
    private static readonly IDictionary<string, Func<IOrderedQueryable<T>, Expression<Func<T, object>>, IOrderedQueryable<T>>> operatorExpressionDict
        = new Dictionary<string, Func<IOrderedQueryable<T>, Expression<Func<T, object>>, IOrderedQueryable<T>>>
        {
            { Consts.Operators.Asc, Queryable.ThenBy },
            { Consts.Operators.Desc, Queryable.ThenByDescending }
        };

    public Func<IOrderedQueryable<T>, IOrderedQueryable<T>> Provide(
        string @operator,
        Expression<Func<T, object>> lambda)
        => !operatorExpressionDict.TryGetValue(@operator, out var queryableFunc)
            ? throw InvalidSortingOrFilteringDataException.CreateWhenOperatorIsIncorrect(@operator)
            : queryable => queryableFunc(queryable, lambda);
}
