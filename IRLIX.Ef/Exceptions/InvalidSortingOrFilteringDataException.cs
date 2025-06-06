using IRLIX.Core.Attributes;
using IRLIX.Core.Exceptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IRLIX.Ef.Exceptions;

[HttpResponseStatusCode(Status400BadRequest)]
public class InvalidSortingOrFilteringDataException(
    string errorMessage,
    Exception? innerEx = null
    ) : DomainException(errorMessage, innerEx)
{
    public override int Code => (int)ExCodes.InvalidSortingOrFilteringData;

    public static InvalidSortingOrFilteringDataException CreateWhenUnknownEx(Exception innerEx)
        => new InvalidSortingOrFilteringDataException("Exception found while executing sorting or filtering", innerEx);

    public static void ThrowWhenConditionsAreEmpty(string[] conditions)
    {
        if (!conditions.Any())
        {
            throw new InvalidSortingOrFilteringDataException($"No conditions detected");
        }
    }

    public static InvalidSortingOrFilteringDataException CreateWhenValueTypeIsIncorrect(object value, Exception ex)
        => new InvalidSortingOrFilteringDataException($"Field type '{value}' is incorrect: {ex.Message}", ex);

    public static InvalidSortingOrFilteringDataException CreateWhenFieldIsIncorrect(string fieldName, Exception ex)
        => new InvalidSortingOrFilteringDataException($"Field name '{fieldName}' is incorrect", ex);

    public static InvalidSortingOrFilteringDataException CreateWhenOperatorIsIncorrect(string @operator)
        => new InvalidSortingOrFilteringDataException($"Operator '{@operator}' is incorrect");

    public static InvalidSortingOrFilteringDataException CreateWhenExpressionPartsCountIsIncorrect(string condition)
        => new InvalidSortingOrFilteringDataException($"Count of parts in condition '{condition}' is incorrect");
}
