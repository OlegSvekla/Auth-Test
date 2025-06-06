using NJsonSchema;

namespace IRLIX.Core.NJsons.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class SchemaMinimumAttribute(
    decimal Value
    ) : Attribute, ISchemaPropertyAttribute
{
    public void Apply(JsonSchema schema)
        => schema.Minimum = Value;
}
