using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Services
{
    public class RootServiceSet : IRootServiceSet
    {
        public IHomeAssistantWebSocketsClient Client { get; }

        public RootServiceSet(IHomeAssistantWebSocketsClient client)
        {
            Client = client;
        }
    }
}