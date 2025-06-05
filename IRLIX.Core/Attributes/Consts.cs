namespace IRLIX.Core.Attributes;

public class Consts
{
    public const string SoftDeletePropertyName = "DeletedDate";

    public static readonly Type SoftDeletePropertyType = typeof(DateTime?);
}
