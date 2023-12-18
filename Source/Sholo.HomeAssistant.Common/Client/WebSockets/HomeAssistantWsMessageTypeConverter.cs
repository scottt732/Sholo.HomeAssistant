using System;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.WebSockets;

public class HomeAssistantWsMessageTypeConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        writer.WriteValue(value?.ToString());
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var str = reader.Value?.ToString();
        if (str == null)
        {
            return null;
        }

        return HomeAssistantWsMessageTypes.Instance.GetOrCreate(str, out _);
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(HomeAssistantWsMessageType);
    }
}
