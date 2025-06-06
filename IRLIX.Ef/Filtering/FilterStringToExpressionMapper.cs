using IRLIX.Core.Interfaces.Mappers;
using IRLIX.Ef.Exceptions;
using IRLIX.Ef.Helpers;
using System.Linq.Expressions;

namespace IRLIX.Ef.Filtering;

public interface IFilterStringToExpressionMapper<T>
    : IMapper<string?, Expression<Func<T, bool>>?>
{
}

public class FilterStringToExpressionMapper<T>(
    IFilterExpressionByOperatorProvider filterExpressionByOperatorProvider
    ) : IFilterStringToExpressionMapper<T>
{
    public Expression<Func<T, bool>>? Map(string? input)
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

    private Expression<Func<T, bool>> InnerMap(string input)
    {
        var conditions = input.Split(Consts.ConditionsSeparator);
        InvalidSortingOrFilteringDataException.ThrowWhenConditionsAreEmpty(conditions);

        var parameter = Expression.Parameter(typeof(T), Consts.ExpressionArgName);

        var result = conditions
            .Select(condition => BuildExpression(condition, parameter))
            .Aggregate(
                Expression.Lambda(Expression.Constant(true), Expression.Parameter(typeof(bool))).Body,
                Expression.AndAlso,
                combinedExpression => Expression.Lambda<Func<T, bool>>(combinedExpression, parameter));
        return result;
    }

    private Expression BuildExpression(string condition, ParameterExpression parameter)
    {
        var parts = condition.Split(Consts.ExpressionSeparator);
        if (parts.Length != Consts.ExpressionPartsCount)
        {
            throw InvalidSortingOrFilteringDataException.CreateWhenExpressionPartsCountIsIncorrect(condition);
        }

        var (field, @operator, value) = (parts[0], parts[1], parts[2]);

        var property = ExpressionHelper.Property(parameter, field);
        var expressionByOperatorFunc = filterExpressionByOperatorProvider.Provide(@operator);

        var expression = expressionByOperatorFunc(property, value);
        return expression;
    }
}
