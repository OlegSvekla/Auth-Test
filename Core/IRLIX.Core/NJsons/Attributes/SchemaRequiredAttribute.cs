using NJsonSchema;

namespace IRLIX.Core.NJsons.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
public class SchemaRequiredAttribute(
    params string[] Values
    ) : Attribute, ISchemaClassAttribute, ISchemaPropertyAttribute
{
    public void Apply(JsonSchema schema)
    {
        foreach (var value in Values)
        {
            schema.RequiredProperties.Add(value);
        }
    }
}
