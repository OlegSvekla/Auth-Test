using IRLIX.Ef.Exceptions;
using IRLIX.Ef.Helpers;
using System.ComponentModel;
using System.Linq.Expressions;

namespace IRLIX.Ef.Filtering;

public interface IFilterExpressionByOperatorProvider
{
    Func<Expression, string, Expression> Provide(string @operator);
}

public class FilterExpressionByOperatorProvider : IFilterExpressionByOperatorProvider
{
    private static readonly Dictionary<string, Func<Expression, string, Expression>> operatorExpressionDict
        = new Dictionary<string, Func<Expression, string, Expression>>
        {
            { Consts.Operators.Eq, GetEqualsExpression },
            { Consts.Operators.Neq, GetNotEqualsExpression },
            { Consts.Operators.Ss, GetSubstringExpression },
            { Consts.Operators.Gt, GetGreaterThanExpression },
            { Consts.Operators.Gte, GetGreaterThanOrEqualExpression },
            { Consts.Operators.Lt, GetLessThanExpression },
            { Consts.Operators.Lte, GetLessThanOrEqualExpression }
        };

    public Func<Expression, string, Expression> Provide(string @operator)
        => !operatorExpressionDict.TryGetValue(@operator, out var expression)
            ? throw InvalidSortingOrFilteringDataException.CreateWhenOperatorIsIncorrect(@operator)
            : expression;

    private static Expression GetEqualsExpression(
        Expression property,
        string value)
    {
        var converer = TypeDescriptor.GetConverter(property.Type);
        var castedValue = converer.InnerConvertFrom(value);
        var constant = Expression.Constant(castedValue, property.Type);
        return Expression.Equal(property, constant);
    }

    private static Expression GetNotEqualsExpression(
        Expression property,
        string value)
    {
        var converter = TypeDescriptor.GetConverter(property.Type);
        var castedValue = converter.InnerConvertFrom(value);
        var constant = Expression.Constant(castedValue, property.Type);
        return Expression.NotEqual(property, constant);
    }

    private static Expression GetSubstringExpression(
        Expression property,
        string value)
    {
        var method = typeof(string).GetMethod(nameof(string.Contains), [typeof(string)])!;
        var constant = Expression.Constant(value, typeof(string));
        return Expression.Call(property, method, constant);
    }

    private static Expression GetGreaterThanExpression(
        Expression property,
        string value)
    {
        var converer = TypeDescriptor.GetConverter(property.Type);
        var castedValue = converer.InnerConvertFrom(value);
        var constant = Expression.Constant(castedValue, property.Type);
        return Expression.GreaterThan(property, constant);
    }

    private static Expression GetGreaterThanOrEqualExpression(
        Expression property,
        string value)
    {
        var converer = TypeDescriptor.GetConverter(property.Type);
        var castedValue = converer.InnerConvertFrom(value);
        var constant = Expression.Constant(castedValue, property.Type);
        return Expression.GreaterThanOrEqual(property, constant);
    }

    private static Expression GetLessThanExpression(
        Expression property,
        string value)
    {
        var converer = TypeDescriptor.GetConverter(property.Type);
        var castedValue = converer.InnerConvertFrom(value);
        var constant = Expression.Constant(castedValue, property.Type);
        return Expression.LessThan(property, constant);
    }

    private static Expression GetLessThanOrEqualExpression(
        Expression property,
        string value)
    {
        var converer = TypeDescriptor.GetConverter(property.Type);
        var castedValue = converer.InnerConvertFrom(value);
        var constant = Expression.Constant(castedValue, property.Type);
        return Expression.LessThanOrEqual(property, constant);
    }
}
