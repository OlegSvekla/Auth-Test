using NJsonSchema;

namespace IRLIX.Core.Serializers;

public interface ISchemaGenerator
{
    JsonSchema GenerateSchema<T>();

    JsonSchema GenerateSchema(Type type);
}
