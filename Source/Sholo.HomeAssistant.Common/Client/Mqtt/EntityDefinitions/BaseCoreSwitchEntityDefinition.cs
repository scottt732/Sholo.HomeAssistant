namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public abstract class BaseCoreSwitchEntityDefinition : BaseStatefulEntityDefinition, ICoreSwitchEntityDefinition
{
    public string CommandTopic { get; internal set; } = null!;
    public bool? Optimistic { get; internal set; }
}
