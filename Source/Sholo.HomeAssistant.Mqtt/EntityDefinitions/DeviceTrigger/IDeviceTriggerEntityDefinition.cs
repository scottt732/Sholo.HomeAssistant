using JetBrains.Annotations;
using MQTTnet.Protocol;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.DeviceTrigger
{
    [PublicAPI]
    public interface IDeviceTriggerEntityDefinition : IEntityDefinition
    {
        /// <summary>
        /// The type of automation, must be ‘trigger'.
        /// </summary>
        string AutomationType { get; }

        /// <summary>
        /// Optional payload to match the payload being sent over the topic.
        /// </summary>
        string Payload { get; }

        /// <summary>
        /// The maximum QoS level to be used when receiving messages.
        /// </summary>
        MqttQualityOfServiceLevel? Qos { get; }

        /// <summary>
        /// The MQTT topic subscribed to receive trigger events.
        /// </summary>
        string Topic { get; }

        /// <summary>
        /// The type of the trigger, e.g. button_short_press. Entries supported by the frontend: button_short_press, button_short_release, button_long_press, button_long_release, button_double_press, button_triple_press, button_quadruple_press, button_quintuple_press. If set to an unsupported value, will render as subtype type, e.g. First button spammed with type set to spammed and subtype set to button_1
        /// </summary>
        DeviceTriggerType Type { get; }

        /// <summary>
        /// The subtype of the trigger, e.g. button_1. Entries supported by the frontend: turn_on, turn_off, button_1, button_2, button_3, button_4, button_5, button_6. If set to an unsupported value, will render as subtype type, e.g. left_button pressed with type set to button_short_press and subtype set to left_button
        /// </summary>
        DeviceTriggerSubType Subtype { get; }
    }
}
