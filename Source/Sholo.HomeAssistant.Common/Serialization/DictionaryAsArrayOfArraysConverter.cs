using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sholo.HomeAssistant.Serialization;

public class DictionaryAsArrayOfArraysConverter<TKey, TValue> : JsonConverter
    where TKey : notnull
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        var dictValue = (IEnumerable<KeyValuePair<TKey, TValue>>)value;

        writer.WriteStartArray();
        foreach (var (itemKey, itemValue) in dictValue)
        {
            writer.WriteStartArray();

            serializer.Serialize(writer, itemKey);
            serializer.Serialize(writer, itemValue);

            writer.WriteEndArray();
        }

        writer.WriteEndArray();
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        return JArray.Load(reader)
            .Cast<JArray>()
            .ToDictionary(
                x => x[0].ToObject<TKey>(serializer)!,
                x => x[1].ToObject<TValue>(serializer)
            );
    }

    public override bool CanConvert(Type objectType)
    {
        return typeof(IEnumerable<KeyValuePair<TKey, TValue>>).IsAssignableFrom(objectType);
    }
}
