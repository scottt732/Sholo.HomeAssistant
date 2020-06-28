using JetBrains.Annotations;
using MQTTnet.Protocol;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions
{
    [PublicAPI]
    public interface IStatefulEntityDefinition : IEntityDefinition
    {
        /// <summary>
        /// The MQTT topic subscribed to receive birth and LWT messages from the MQTT device. If
        /// availability_topic is not defined, the binary sensor availability state will always
        /// be available. If availability_topic is defined, the entity availability state will be
        /// unavailable by default.
        /// </summary>
        string AvailabilityTopic { get; }

        /// <summary>
        /// Defines a template to extract the JSON dictionary from messages received on the
        /// json_attributes_topic. Usage example can be found in MQTT sensor documentation.
        /// </summary>
        string JsonAttributesTemplate { get; }

        /// <summary>
        /// The MQTT topic subscribed to receive a JSON dictionary payload and then set as sensor
        /// attributes. Usage example can be found in MQTT sensor documentation.
        /// </summary>
        string JsonAttributesTopic { get; }

        /// <summary>
        /// The payload that represents the online state.
        /// </summary>
        string PayloadAvailable { get; }

        /// <summary>
        /// The payload that represents the offline state.
        /// </summary>
        string PayloadNotAvailable { get; }

        /// <summary>
        /// The maximum QoS level to be used when receiving messages.
        /// </summary>
        MqttQualityOfServiceLevel? Qos { get; }

        /// <summary>
        /// If the published message should have the retain flag on or not.
        /// </summary>
        bool? Retain { get; }

        /// <summary>
        /// The MQTT topic subscribed to receive sensor values.
        /// </summary>
        string StateTopic { get; }

        /// <summary>
        /// Defines a template to extract a value from the payload. Available variables: entity_id.
        /// Remove this option when ‘payload_...' and ‘payload_...' are sufficient to match your
        /// payloads.
        /// </summary>
        string ValueTemplate { get; }
    }
}
