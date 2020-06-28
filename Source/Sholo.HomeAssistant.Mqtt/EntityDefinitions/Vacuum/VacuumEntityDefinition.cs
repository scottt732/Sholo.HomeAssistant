namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Vacuum
{
    public class VacuumEntityDefinition : BaseStatefulEntityDefinition, IVacuumEntityDefinition
    {
        public string CommandTopic { get; internal set; }
        public string[] FanSpeedList { get; internal set; }
        public string PayloadCleanSpot { get; internal set; }
        public string PayloadLocate { get; internal set; }
        public string PayloadPause { get; internal set; }
        public string PayloadReturnToBase { get; internal set; }
        public string PayloadStart { get; internal set; }
        public string PayloadStop { get; internal set; }
        public string Schema { get; internal set; }
        public string SendCommandTopic { get; internal set; }
        public string SetFanSpeedTopic { get; internal set; }
        public VacuumFeature[] SupportedFeatures { get; internal set; }
    }
}