using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.Rest;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Context
{
    [PublicAPI]
    public interface IHomeAssistantContext
    {
        IHomeAssistantRestClient RestClient { get; }
        IHomeAssistantWebSocketsClient WebSocketsClient { get; }
        IHomeAssistantEntitiesContext Entities { get; }
        IHomeAssistantServicesContext Services { get; }
    }
}
