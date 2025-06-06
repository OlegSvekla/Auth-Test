using NJsonSchema;

namespace IRLIX.Core.NJsons.Attributes;

public interface ISchemaClassAttribute
{
    void Apply(JsonSchema schema);
}
