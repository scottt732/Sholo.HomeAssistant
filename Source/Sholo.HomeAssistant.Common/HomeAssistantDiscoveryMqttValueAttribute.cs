using System;

namespace Sholo.HomeAssistant;

[AttributeUsage(AttributeTargets.Field)]
public sealed class HomeAssistantDiscoveryMqttValueAttribute : Attribute
{
    public string MqttString { get; }

    public HomeAssistantDiscoveryMqttValueAttribute(string mqttString)
    {
        MqttString = mqttString;
    }
}
