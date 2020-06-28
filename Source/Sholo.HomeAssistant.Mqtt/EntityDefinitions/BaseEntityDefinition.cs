using Sholo.HomeAssistant.Mqtt.Discovery.Payloads;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions
{
    public abstract class BaseEntityDefinition : BaseDefinition, IEntityDefinition
    {
        public IDevice Device { get; internal set; }
        public string Name { get; internal set; }
        public string UniqueId { get; internal set; }
    }
}