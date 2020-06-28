using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.DeviceTrigger
{
    [PublicAPI]
    public enum DeviceTriggerType
    {
        [HomeAssistantMqttValue("button_short_press")]
        ButtonShortPress,

        [HomeAssistantMqttValue("button_short_release")]
        ButtonShortRelease,

        [HomeAssistantMqttValue("button_long_press")]
        ButtonLongPress,

        [HomeAssistantMqttValue("button_long_release")]
        ButtonLongRelease,

        [HomeAssistantMqttValue("button_double_press")]
        ButtonDoublePress,

        [HomeAssistantMqttValue("button_triple_press")]
        ButtonTriplePress,

        [HomeAssistantMqttValue("button_quadruple_press")]
        ButtonQuadruplePress,

        [HomeAssistantMqttValue("button_quintuple_press")]
        ButtonQuintuplePress,

        [HomeAssistantMqttValue("spammed")]
        Spammed
    }
}
