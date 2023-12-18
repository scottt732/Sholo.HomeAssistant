namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public class Availability
{
    /// <summary>
    /// An MQTT topic subscribed to receive availability (online/offline) updates (required)
    /// </summary>
    public string Topic { get; init; } = null!;

    /// <summary>
    /// The payload that represents the available state.
    /// </summary>
    public string? PayloadAvailable { get; init; }

    /// <summary>
    /// The payload that represents the unavailable state.
    /// </summary>
    public string? PayloadNotAvailable { get; init; }

    /// <summary>
    /// Defines a template to extract device's availability from the topic. To determine the
    /// device's availability result of this template will be compared to payload_available
    /// and payload_not_available.
    /// </summary>
    public string? ValueTemplate { get; init; }
}
