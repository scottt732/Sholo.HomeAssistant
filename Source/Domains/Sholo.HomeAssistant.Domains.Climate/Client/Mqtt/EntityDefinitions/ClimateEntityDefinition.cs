namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public class ClimateEntityDefinition : BaseStatefulEntityDefinition, IClimateEntityDefinition
{
    public string ActionTemplate { get; internal set; } = null!;
    public string ActionTopic { get; internal set; } = null!;
    public string AuxCommandTopic { get; internal set; } = null!;
    public string AuxStateTemplate { get; internal set; } = null!;
    public string AuxStateTopic { get; internal set; } = null!;
    public string AwayModeCommandTopic { get; internal set; } = null!;
    public string AwayModeStateTemplate { get; internal set; } = null!;
    public string AwayModeStateTopic { get; internal set; } = null!;
    public string CurrentTemperatureTemplate { get; internal set; } = null!;
    public string CurrentTemperatureTopic { get; internal set; } = null!;
    public string FanModeCommandTopic { get; internal set; } = null!;
    public string FanModeStateTemplate { get; internal set; } = null!;
    public string FanModeStateTopic { get; internal set; } = null!;
    public string[] FanModes { get; internal set; } = null!;
    public string HoldCommandTopic { get; internal set; } = null!;
    public string HoldStateTemplate { get; internal set; } = null!;
    public string HoldStateTopic { get; internal set; } = null!;
    public string[] HoldModes { get; internal set; } = null!;
    public int? Initial { get; internal set; }
    public float? MaxTemp { get; internal set; }
    public float? MinTemp { get; internal set; }
    public string ModeCommandTopic { get; internal set; } = null!;
    public string ModeStateTemplate { get; internal set; } = null!;
    public string ModeStateTopic { get; internal set; } = null!;
    public string[] Modes { get; internal set; } = null!;
    public string PayloadOff { get; internal set; } = null!;
    public string PayloadOn { get; internal set; } = null!;
    public string PowerCommandTopic { get; internal set; } = null!;
    public float? Precision { get; internal set; }
    public bool? SendIfOff { get; internal set; }
    public string SwingModeCommandTopic { get; internal set; } = null!;
    public string SwingModeStateTemplate { get; internal set; } = null!;
    public string SwingModeStateTopic { get; internal set; } = null!;
    public string[] SwingModes { get; internal set; } = null!;
    public string TemperatureCommandTopic { get; internal set; } = null!;
    public string TemperatureHighCommandTopic { get; internal set; } = null!;
    public string TemperatureHighStateTemplate { get; internal set; } = null!;
    public string TemperatureHighStateTopic { get; internal set; } = null!;
    public string TemperatureLowCommandTopic { get; internal set; } = null!;
    public string TemperatureLowStateTemplate { get; internal set; } = null!;
    public string TemperatureLowStateTopic { get; internal set; } = null!;
    public string TemperatureStateTemplate { get; internal set; } = null!;
    public string TemperatureStateTopic { get; internal set; } = null!;
    public float? TempStep { get; internal set; }
}
