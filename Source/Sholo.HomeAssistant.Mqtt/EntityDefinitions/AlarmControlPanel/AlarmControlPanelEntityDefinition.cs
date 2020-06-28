namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.AlarmControlPanel
{
    public class AlarmControlPanelEntityDefinition : BaseStatefulEntityDefinition, IAlarmControlPanelEntityDefinition
    {
        public string Code { get; internal set; }
        public bool? CodeArmRequired { get; internal set; }
        public bool? CodeDisarmRequired { get; internal set; }
        public string CommandTemplate { get; internal set; }
        public string CommandTopic { get; internal set; }
        public string PayloadArmAway { get; internal set; }
        public string PayloadArmHome { get; internal set; }
        public string PayloadArmNight { get; internal set; }
        public string PayloadDisarm { get; internal set; }
    }
}
