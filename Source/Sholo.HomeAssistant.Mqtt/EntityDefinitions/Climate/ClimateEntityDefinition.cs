using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Climate
{
    [PublicAPI]
    public class ClimateEntityDefinition : BaseStatefulEntityDefinition, IClimateEntityDefinition
    {
        public string ActionTemplate { get; internal set; }
        public string ActionTopic { get; internal set; }
        public string AuxCommandTopic { get; internal set; }
        public string AuxStateTemplate { get; internal set; }
        public string AuxStateTopic { get; internal set; }
        public string AwayModeCommandTopic { get; internal set; }
        public string AwayModeStateTemplate { get; internal set; }
        public string AwayModeStateTopic { get; internal set; }
        public string CurrentTemperatureTemplate { get; internal set; }
        public string CurrentTemperatureTopic { get; internal set; }
        public string FanModeCommandTopic { get; internal set; }
        public string FanModeStateTemplate { get; internal set; }
        public string FanModeStateTopic { get; internal set; }
        public string[] FanModes { get; internal set; }
        public string HoldCommandTopic { get; internal set; }
        public string HoldStateTemplate { get; internal set; }
        public string HoldStateTopic { get; internal set; }
        public string[] HoldModes { get; internal set; }
        public int? Initial { get; internal set; }
        public float? MaxTemp { get; internal set; }
        public float? MinTemp { get; internal set; }
        public string ModeCommandTopic { get; internal set; }
        public string ModeStateTemplate { get; internal set; }
        public string ModeStateTopic { get; internal set; }
        public string[] Modes { get; internal set; }
        public string PayloadOff { get; internal set; }
        public string PayloadOn { get; internal set; }
        public string PowerCommandTopic { get; internal set; }
        public float? Precision { get; internal set; }
        public bool? SendIfOff { get; internal set; }
        public string SwingModeCommandTopic { get; internal set; }
        public string SwingModeStateTemplate { get; internal set; }
        public string SwingModeStateTopic { get; internal set; }
        public string[] SwingModes { get; internal set; }
        public string TemperatureCommandTopic { get; internal set; }
        public string TemperatureHighCommandTopic { get; internal set; }
        public string TemperatureHighStateTemplate { get; internal set; }
        public string TemperatureHighStateTopic { get; internal set; }
        public string TemperatureLowCommandTopic { get; internal set; }
        public string TemperatureLowStateTemplate { get; internal set; }
        public string TemperatureLowStateTopic { get; internal set; }
        public string TemperatureStateTemplate { get; internal set; }
        public string TemperatureStateTopic { get; internal set; }
        public float? TempStep { get; internal set; }
    }
}
