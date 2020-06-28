using Sholo.HomeAssistant.DeviceClasses;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Cover
{
    public class CoverEntityDefinition : BaseCoreSwitchEntityDefinition, ICoverEntityDefinition
    {
        public CoverDeviceClass? DeviceClass { get; internal set; }
        public string PayloadClose { get; internal set; }
        public string PayloadOpen { get; internal set; }
        public string PayloadStop { get; internal set; }
        public int? PositionClosed { get; internal set; }
        public int? PositionOpen { get; internal set; }
        public string PositionTopic { get; internal set; }
        public string SetPositionTemplate { get; internal set; }
        public string SetPositionTopic { get; internal set; }
        public string StateClosed { get; internal set; }
        public string StateClosing { get; internal set; }
        public string StateOpen { get; internal set; }
        public string StateOpening { get; internal set; }
        public int? TiltClosedValue { get; internal set; }
        public string TiltCommandTopic { get; internal set; }
        public bool? TiltInvertState { get; internal set; }
        public int? TiltMax { get; internal set; }
        public int? TiltMin { get; internal set; }
        public int? TiltOpenedValue { get; internal set; }
        public bool? TiltOptimistic { get; internal set; }
        public string TiltStatusTemplate { get; internal set; }
        public string TiltStatusTopic { get; internal set; }
    }
}
