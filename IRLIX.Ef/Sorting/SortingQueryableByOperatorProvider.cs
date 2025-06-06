using IRLIX.Ef.Exceptions;
using System.Linq.Expressions;

namespace IRLIX.Ef.Sorting;

public interface ISortingQueryableByOperatorProvider<T>
{
    Func<IQueryable<T>, IOrderedQueryable<T>> Provide(
        string @operator,
        Expression<Func<T, object>> lambda);
}

public class SortingQueryableByOperatorProvider<T> : ISortingQueryableByOperatorProvider<T>
{
    private static readonly IDictionary<string, Func<IQueryable<T>, Expression<Func<T, object>>, IOrderedQueryable<T>>> operatorExpressionDict
        = new Dictionary<string, Func<IQueryable<T>, Expression<Func<T, object>>, IOrderedQueryable<T>>>
        {
            { Consts.Operators.Asc, Queryable.OrderBy },
            { Consts.Operators.Desc, Queryable.OrderByDescending }
        };

    public Func<IQueryable<T>, IOrderedQueryable<T>> Provide(
        string @operator,
        Expression<Func<T, object>> lambda)
        => !operatorExpressionDict.TryGetValue(@operator, out var queryableFunc)
            ? throw InvalidSortingOrFilteringDataException.CreateWhenOperatorIsIncorrect(@operator)
            : queryable => queryableFunc(queryable, lambda);
}
