namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public enum DeviceTopicType
{
    [HomeAssistantMqttValue("config")]
    Config,

    [HomeAssistantMqttValue("state")]
    State,
}
