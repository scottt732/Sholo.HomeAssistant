namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions
{
    public abstract class BaseCoreSensorEntityDefinition : BaseStatefulEntityDefinition, ICoreSensorEntityDefinition
    {
        public int? ExpireAfter { get; internal set; }
        public bool? ForceUpdate { get; internal set; }
    }
}