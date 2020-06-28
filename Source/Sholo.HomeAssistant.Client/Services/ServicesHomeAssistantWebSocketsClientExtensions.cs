using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Services
{
    public static class ServicesHomeAssistantWebSocketsClientExtensions
    {
        public static IRootServiceSet Services(this IHomeAssistantWebSocketsClient client)
            => new RootServiceSet(client);
    }
}
