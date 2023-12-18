using Sholo.HomeAssistant.Client.Mqtt.Devices;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public abstract class BaseEntityDefinition : BaseDefinition, IEntityDefinition
{
    public IDevice Device { get; internal set; } = null!;
    public string? Name { get; internal set; }
    public string UniqueId { get; internal set; } = null!;
    public string? ObjectId { get; internal set; }
}
