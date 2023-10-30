using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

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

        settings.Converters.Add(
            new StringEnumConverter(snakeCaseNamingStrategy)
        );

        return settings;
    }
}
