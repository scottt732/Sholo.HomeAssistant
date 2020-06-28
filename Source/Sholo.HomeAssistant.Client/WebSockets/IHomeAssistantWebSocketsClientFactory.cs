using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.WebSockets
{
    [PublicAPI]
    public interface IHomeAssistantWebSocketsClientFactory
    {
        public IHomeAssistantWebSocketsClient CreateClient();
    }
}
