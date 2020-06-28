namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions
{
    public abstract class BaseCoreSwitchEntityDefinition : BaseStatefulEntityDefinition, ICoreSwitchEntityDefinition
    {
        public string CommandTopic { get; internal set; }
        public bool? Optimistic { get; internal set; }
    }
}