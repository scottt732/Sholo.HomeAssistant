namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public abstract class BaseCoreSensorEntityDefinition : BaseStatefulEntityDefinition, ICoreSensorEntityDefinition
{
    public int? ExpireAfter { get; set; }
    public bool? ForceUpdate { get; set; }
}
