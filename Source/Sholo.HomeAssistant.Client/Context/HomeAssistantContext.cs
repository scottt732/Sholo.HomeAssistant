using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.Rest;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Context
{
    [PublicAPI]
    public class HomeAssistantContext : IHomeAssistantContext
    {
        public IHomeAssistantRestClient RestClient { get; }
        public IHomeAssistantWebSocketsClient WebSocketsClient { get; }
        public IHomeAssistantEntitiesContext Entities { get; }
        public IHomeAssistantServicesContext Services { get; }

        public HomeAssistantContext(IHomeAssistantRestClient restClient, IHomeAssistantWebSocketsClient webSocketsClient)
        {
            RestClient = restClient;
            WebSocketsClient = webSocketsClient;
            Entities = new HomeAssistantEntitiesContext(this);
            Services = new HomeAssistantServicesContext(this);
        }
    }
}
