namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public class DeviceTriggerEntityDefinition : BaseEntityDefinition, IDeviceTriggerEntityDefinition
{
    public string AutomationType { get; internal set; } = null!;
    public string Payload { get; internal set; } = null!;
    public QualityOfServiceLevel? Qos { get; internal set; }
    public string Topic { get; internal set; } = null!;
    public DeviceTriggerType Type { get; internal set; }
    public DeviceTriggerSubType Subtype { get; internal set; }
}
