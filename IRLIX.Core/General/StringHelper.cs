using IRLIX.Core.General.Models;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace IRLIX.Core.General;

public static class StringHelper
{
    public const string LowerCaseEnglishAlphabet = "abcdefghijklmnopqrstuvwxyz";
    public const string UpperCaseEnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public const string Numerics = "0123456789";
    public const string SpecialSymbols = "!@#$%^&*_-=+";

    public static bool MatchRegex(
        this string value,
        string pattern)
        => Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase);

    public static string ToCsvList(
        this IEnumerable<string> value)
        => string.Join(',', value);

    public static string RemoveSuffixWhenFound(
        this string value,
        string suffix)
        => value.EndsWith(suffix, StringComparison.InvariantCultureIgnoreCase)
        ? value[..^suffix.Length]
        : value;

    public static string AsLengthOfRandomString(
        this int length,
        IReadOnlyCollection<StringSymbolsType>? stringSymbolsTypes = null)
    {
        stringSymbolsTypes ??= [
            StringSymbolsType.LowerCaseEnglishAlphabet,
            StringSymbolsType.UpperCaseEnglishAlphabet,
            StringSymbolsType.Numerics,
            StringSymbolsType.SpecialSymbols
        ];
        var symbolsStr = string.Join(string.Empty, stringSymbolsTypes);
        var symbols = symbolsStr.ToCharArray();

        var result = RandomNumberGenerator.GetString(symbols, length);
        return result;
    }

    public static string ReplaceSpecialCharsInPrivateKey(string value)
        => value.Replace("‰", "\n");
}
