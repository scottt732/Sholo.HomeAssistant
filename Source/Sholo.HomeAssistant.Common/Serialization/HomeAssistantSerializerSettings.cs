using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Sholo.HomeAssistant.Client.Shared.EntityStates;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;

namespace Sholo.HomeAssistant.Serialization;

public static class HomeAssistantSerializerSettings
{
    public static JsonSerializerSettings JsonSerializerSettings => JsonSerializerSettingsFactory.Value;
    public static JsonSerializerSettings IndentedJsonSerializerSettings => IndentedJsonSerializerSettingsFactory.Value;

    private static readonly Lazy<JsonSerializerSettings> JsonSerializerSettingsFactory = new(() => CreateJsonSerializerSettings(Formatting.None));
    private static readonly Lazy<JsonSerializerSettings> IndentedJsonSerializerSettingsFactory = new(() => CreateJsonSerializerSettings(Formatting.Indented));

    public static JsonSerializerSettings CreateJsonSerializerSettings(Formatting formatting, IContractResolver? contractResolver = null)
    {
        var snakeCaseNamingStrategy = new SnakeCaseNamingStrategy();

        var settings = new JsonSerializerSettings
        {
            ContractResolver = contractResolver ?? new DefaultContractResolver
            {
                NamingStrategy = snakeCaseNamingStrategy
            },
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = formatting
        };

        settings.Converters.Add(new AbstractConverter<IEntityStateContext, EntityStateContext>());
        settings.Converters.Add(new AbstractConverter(typeof(IEventMessage<>), typeof(EventMessage<>)));
        settings.Converters.Add(new AbstractConverter(typeof(IEntityState<,>), typeof(EntityState<,>)));
        settings.Converters.Add(new AbstractConverter(typeof(IEntityState<>), typeof(EntityState<>)));
        settings.Converters.Add(new AbstractConverter(typeof(IEntityState), typeof(EntityState)));
        settings.Converters.Add(new StringEnumConverter(snakeCaseNamingStrategy));

        return settings;
    }
}

public class AbstractConverter : JsonConverter
{
    private Type InterfaceType { get; }
    private Type ImplementationType { get; }

    public AbstractConverter(Type interfaceType, Type implementationType)
    {
        InterfaceType = interfaceType;
        ImplementationType = implementationType;
    }

    public override bool CanConvert(Type objectType)
        => objectType == InterfaceType;

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        => serializer.Deserialize(reader, ImplementationType);

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        => serializer.Serialize(writer, value);
}

public class AbstractConverter<TInterface, TImplementation> : JsonConverter
    where TImplementation : class, TInterface
{
    public override bool CanConvert(Type objectType)
        => objectType == typeof(TInterface);

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        => serializer.Deserialize<TImplementation>(reader);

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        => serializer.Serialize(writer, value);
}
