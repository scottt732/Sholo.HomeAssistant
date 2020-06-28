using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Context
{
    [PublicAPI]
    public interface IHomeAssistantEntitiesContext
    {
        IHomeAssistantContext Context { get; }
    }
}
