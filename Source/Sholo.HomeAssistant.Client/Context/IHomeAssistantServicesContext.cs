using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Context
{
    [PublicAPI]
    public interface IHomeAssistantServicesContext
    {
        IHomeAssistantContext Context { get; }
    }
}
