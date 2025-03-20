using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UDS.Test.Repositories.Converters;

public class SingleOrArrayConverter : JsonConverter<List<string>>
{
    public override List<string> ReadJson(JsonReader reader, Type objectType, List<string>? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var token = JToken.Load(reader);

        if (token.Type == JTokenType.String)
        {
            return [token.ToString()];
        }
        else if (token.Type == JTokenType.Array)
        {
            return token.ToObject<List<string>>() ?? new List<string>();
        }

        throw new JsonSerializationException("Unexpected token type for 'masters' field.");
    }

    public override void WriteJson(JsonWriter writer, List<string>? value, JsonSerializer serializer)
    {
        if (value?.Count == 1)
        {
            writer.WriteValue(value[0]);
        }
        else
        {
            serializer.Serialize(writer, value);
        }
    }
}