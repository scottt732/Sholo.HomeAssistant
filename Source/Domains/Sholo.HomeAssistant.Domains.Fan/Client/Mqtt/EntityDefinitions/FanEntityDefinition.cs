namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public class FanEntityDefinition : BaseCoreSwitchEntityDefinition, IFanEntityDefinition
{
    public string OscillationCommandTopic { get; internal set; } = null!;
    public string OscillationStateTopic { get; internal set; } = null!;
    public string? OscillationValueTemplate { get; internal set; }
    public string PayloadHighSpeed { get; internal set; } = null!;
    public string PayloadLowSpeed { get; internal set; } = null!;
    public string PayloadMediumSpeed { get; internal set; } = null!;
    public string PayloadOff { get; internal set; } = null!;
    public string PayloadOn { get; internal set; } = null!;
    public string PayloadOscillationOff { get; internal set; } = null!;
    public string PayloadOscillationOn { get; internal set; } = null!;
    public string SpeedCommandTopic { get; internal set; } = null!;
    public string SpeedStateTopic { get; internal set; } = null!;
    public string? SpeedValueTemplate { get; internal set; }
    public FanSpeed[] Speeds { get; internal set; } = null!;
}
