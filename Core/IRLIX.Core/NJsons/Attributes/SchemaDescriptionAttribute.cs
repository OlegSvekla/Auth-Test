using NJsonSchema;

namespace IRLIX.Core.NJsons.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
public class SchemaDescriptionAttribute(
    string Value
    ) : Attribute, ISchemaPropertyAttribute, ISchemaClassAttribute
{
    public void Apply(JsonSchema schema) 
        => schema.Description = Value;
}
