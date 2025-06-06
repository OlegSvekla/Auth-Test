using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace IRLIX.Ef.Converters;

public static class JsonEfConvertHelper
{
    public static (ValueConverter<IList<T>, string> Converter, ValueComparer<IList<T>> Comparer) GetConverterComparer<T>()
    {
        var converter = new ValueConverter<IList<T>, string>(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<IList<T>>(v) ?? new List<T>());

        var comparer = new ValueComparer<IList<T>>(
            (l, r) => l != null && r != null && l.SequenceEqual(r),
            v => v != null ? v.Aggregate(0, (a, v) => HashCode.Combine(a, v != null ? v.GetHashCode() : 0)) : 0,
            v => v != null ? v.ToList() : new List<T>());

        return (converter, comparer);
    }
}
