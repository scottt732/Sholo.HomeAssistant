using Sholo.HomeAssistant.Mqtt.Entities.Fan;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Fan
{
    public class FanEntityDefinition : BaseCoreSwitchEntityDefinition, IFanEntityDefinition
    {
        public string OscillationCommandTopic { get; internal set; }
        public string OscillationStateTopic { get; internal set; }
        public string OscillationValueTemplate { get; internal set; }
        public string PayloadHighSpeed { get; internal set; }
        public string PayloadLowSpeed { get; internal set; }
        public string PayloadMediumSpeed { get; internal set; }
        public string PayloadOff { get; internal set; }
        public string PayloadOn { get; internal set; }
        public string PayloadOscillationOff { get; internal set; }
        public string PayloadOscillationOn { get; internal set; }
        public string SpeedCommandTopic { get; internal set; }
        public string SpeedStateTopic { get; internal set; }
        public string SpeedValueTemplate { get; internal set; }
        public FanSpeed[] Speeds { get; internal set; }
    }
}