namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch
{
    public class SwitchEntityDefinition : BaseCoreSwitchEntityDefinition, ISwitchEntityDefinition
    {
        public string Icon { get; internal set; }
        public string PayloadOff { get; internal set; }
        public string PayloadOn { get; internal set; }
        public string StateOff { get; internal set; }
        public string StateOn { get; internal set; }
    }
}