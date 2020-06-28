using System;
using Sholo.Utils;

namespace Sholo.HomeAssistant.Utilities
{
    public static class EnumExtensions
    {
        public static string GetHomeAssistantMqttValue(this Enum value)
            => value.GetAttributeValue<HomeAssistantMqttValueAttribute, string>(mqtt => mqtt.MqttString);

        public static string GetHomeAssistantDiscoveryMqttValue(this Enum value)
            => value.GetAttributeValue<HomeAssistantDiscoveryMqttValueAttribute, string>(mqtt => mqtt.MqttString);
    }
}
