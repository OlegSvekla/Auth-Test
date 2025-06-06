namespace IRLIX.Core.General;

public static class AttributeHelper
{
    public static bool HasAttribute<TAttribute>(
        this object value,
        bool inherit = false)
        where TAttribute : Attribute
        => value.GetType().IsDefined(
            attributeType: typeof(TAttribute),
            inherit: inherit);
}
