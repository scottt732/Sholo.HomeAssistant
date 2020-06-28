using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.DeviceTrigger
{
    [PublicAPI]
    public enum DeviceTriggerSubType
    {
        [HomeAssistantMqttValue("turn_on")]
        TurnOn,

        [HomeAssistantMqttValue("turn_off")]
        TurnOff,

        [HomeAssistantMqttValue("button_1")]
        Button1,

        [HomeAssistantMqttValue("button_2")]
        Button2,

        [HomeAssistantMqttValue("button_3")]
        Button3,

        [HomeAssistantMqttValue("button_4")]
        Button4,

        [HomeAssistantMqttValue("button_5")]
        Button5,

        [HomeAssistantMqttValue("button_6")]
        Button6
    }
}
