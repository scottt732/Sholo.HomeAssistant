using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt
{
    [PublicAPI]
    public enum DeviceTopicType
    {
        [HomeAssistantMqttValue("config")]
        Config,

        [HomeAssistantMqttValue("state")]
        State,
    }
}
