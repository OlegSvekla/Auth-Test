using IRLIX.Ef.Exceptions;
using System.Linq.Expressions;
using IRLIX.Core.General;

namespace IRLIX.Ef.Helpers;

public static class ExpressionHelper
{
    public static MemberExpression Property(Expression expression, string propertyName)
    {
        try
        {
            var result = Expression.Property(expression, propertyName);
            return result;
        }
        catch (ArgumentException ex)
        when (ex.Message.MatchRegex("Instance property '.*' is not defined for type "))
        {
            throw InvalidSortingOrFilteringDataException.CreateWhenFieldIsIncorrect(propertyName, ex);
        }
    }
}
