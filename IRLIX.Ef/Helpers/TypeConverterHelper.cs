using IRLIX.Ef.Exceptions;
using System.ComponentModel;
using System.Globalization;

namespace IRLIX.Ef.Helpers;

public static class TypeConverterHelper
{
    public static object? InnerConvertFrom(this TypeConverter converer, object value)
    {
        try
        {
            var result = converer.ConvertFrom(null, CultureInfo.InvariantCulture, value);
            return result;
        }
        catch (FormatException ex)
        when (ex.Message.MatchRegex("Unrecognized .* format"))
        {
            throw InvalidSortingOrFilteringDataException.CreateWhenValueTypeIsIncorrect(value, ex);
        }
    }
}
