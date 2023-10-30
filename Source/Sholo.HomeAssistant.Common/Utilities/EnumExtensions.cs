using System;
using System.ComponentModel;
using System.Linq;

namespace Sholo.HomeAssistant.Utilities;

[PublicAPI]
public static class EnumExtensions
{
    public static string? GetHomeAssistantMqttValue(this Enum value)
        => value.GetAttributeValue<HomeAssistantMqttValueAttribute, string>(mqtt => mqtt.MqttString);

    public static string? GetHomeAssistantDiscoveryMqttValue(this Enum value)
        => value.GetAttributeValue<HomeAssistantDiscoveryMqttValueAttribute, string>(mqtt => mqtt.MqttString);

    public static string? GetDescription(this Enum value)
        => value.GetAttributeValue<DescriptionAttribute, string>(d => d.Description);

    public static TAttribute? GetAttribute<TAttribute>(this Enum value)
        where TAttribute : Attribute
        => value.GetAttributeValue<TAttribute, TAttribute>(t => t);

    public static TValue? GetAttributeValue<TAttribute, TValue>(this Enum value, Func<TAttribute, TValue> attributeValueSelector)
        where TAttribute : Attribute
        => value.GetType()
            .GetMember(value.ToString())
            .SelectMany(x => x.GetCustomAttributes(typeof(TAttribute), false))
            .Cast<TAttribute>()
            .Select(attributeValueSelector)
            .FirstOrDefault();
}
