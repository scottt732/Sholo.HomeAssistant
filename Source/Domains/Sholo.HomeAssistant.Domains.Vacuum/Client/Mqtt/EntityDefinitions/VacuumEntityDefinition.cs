namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public class VacuumEntityDefinition : BaseStatefulEntityDefinition, IVacuumEntityDefinition
{
    public string CommandTopic { get; internal set; } = null!;
    public string[] FanSpeedList { get; internal set; } = null!;
    public string PayloadCleanSpot { get; internal set; } = null!;
    public string PayloadLocate { get; internal set; } = null!;
    public string PayloadPause { get; internal set; } = null!;
    public string PayloadReturnToBase { get; internal set; } = null!;
    public string PayloadStart { get; internal set; } = null!;
    public string PayloadStop { get; internal set; } = null!;
    public string Schema { get; internal set; } = null!;
    public string SendCommandTopic { get; internal set; } = null!;
    public string SetFanSpeedTopic { get; internal set; } = null!;
    public VacuumFeature[] SupportedFeatures { get; internal set; } = null!;
}
