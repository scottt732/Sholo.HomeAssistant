using System.Collections.ObjectModel;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public abstract class BaseStatefulEntityDefinition : BaseEntityDefinition, IStatefulEntityDefinition
{
    /// <summary>
    /// A list of MQTT topics subscribed to receive availability (online/offline) updates. Must not
    /// be used together with availability_topic.
    /// </summary>
    public Collection<Availability> Availability { get; } = new();
    public AvailabilityMode AvailabilityMode { get; internal set; } = AvailabilityMode.Latest;
    public string? AvailabilityTopic { get; internal set; }
    public string? AvailabilityTemplate { get; internal set; }
    public string? JsonAttributesTemplate { get; internal set; }
    public string? JsonAttributesTopic { get; internal set; }
    public string? PayloadAvailable { get; internal set; }
    public string? PayloadNotAvailable { get; internal set; }
    public QualityOfServiceLevel? Qos { get; internal set; }
    public bool? Retain { get; internal set; }
    public string StateTopic { get; internal set; } = null!;
    public string? ValueTemplate { get; internal set; }
}
