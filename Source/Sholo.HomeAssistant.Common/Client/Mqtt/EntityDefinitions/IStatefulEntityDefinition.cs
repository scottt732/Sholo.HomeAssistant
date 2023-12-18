using System.Collections.ObjectModel;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public interface IStatefulEntityDefinition : IEntityDefinition
{
    /// <summary>
    /// A list of MQTT topics subscribed to receive availability (online/offline) updates.
    /// Must not be used together with availability_topic.
    /// </summary>
    Collection<Availability> Availability { get; }

    /// <summary>
    /// When <see cref="Availability" /> is configured, this controls the conditions needed
    /// to set the entity to available.
    ///
    /// <list type="bullet">
    ///     <item>
    ///         <description>
    ///             If set to <see cref="AvailabilityMode.All" />, <see cref="Availability.PayloadAvailable"/>
    ///             must be received on all configured availability topics before the entity is marked as online
    ///         </description>
    ///     </item>
    ///     <item>
    ///         <description>
    ///             If set to <see cref="AvailabilityMode.Any"/>, <see cref="Availability.PayloadAvailable"/>
    ///             must be received on at least one configured availability topic before the entity is marked
    ///             as online.
    ///         </description>
    ///     </item>
    ///     <item>
    ///         <description>
    ///             If set to <see cref="AvailabilityMode.Latest"/>, the last <see cref="Availability.PayloadAvailable"/>
    ///             or <see cref="Availability.PayloadNotAvailable"/> received on any configured availability topic
    ///             controls the availability.
    ///         </description>
    ///     </item>
    /// </list>
    /// </summary>
    AvailabilityMode AvailabilityMode { get; }

    /// <summary>
    /// The MQTT topic subscribed to receive birth and LWT messages from the MQTT device. If
    /// availability_topic is not defined, the binary sensor availability state will always
    /// be available. If availability_topic is defined, the entity availability state will be
    /// unavailable by default.
    /// </summary>
    string? AvailabilityTopic { get; }

    /// <summary>
    /// Defines a template to extract device's availability from the availability_topic. To
    /// determine the device's availability result of this template will be compared to
    /// <see cref="PayloadAvailable" /> and <see cref="PayloadNotAvailable" />.
    /// </summary>
    string? AvailabilityTemplate { get; }

    /// <summary>
    /// Defines a template to extract the JSON dictionary from messages received on the
    /// json_attributes_topic. Usage example can be found in MQTT sensor documentation.
    /// </summary>
    string? JsonAttributesTemplate { get; }

    /// <summary>
    /// The MQTT topic subscribed to receive a JSON dictionary payload and then set as sensor
    /// attributes. Usage example can be found in MQTT sensor documentation.
    /// </summary>
    string? JsonAttributesTopic { get; }

    /// <summary>
    /// The payload that represents the online state.
    /// </summary>
    string? PayloadAvailable { get; }

    /// <summary>
    /// The payload that represents the offline state.
    /// </summary>
    string? PayloadNotAvailable { get; }

    /// <summary>
    /// The maximum QoS level to be used when receiving messages.
    /// </summary>
    QualityOfServiceLevel? Qos { get; }

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
    /// Remove this option when 'payload_...' and 'payload_...' are sufficient to match your
    /// payloads.
    /// </summary>
    string? ValueTemplate { get; }
}
