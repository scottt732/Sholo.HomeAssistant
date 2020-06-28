using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Services
{
    public interface IRootServiceSet : IServiceSet
    {
        IHomeAssistantWebSocketsClient Client { get; }
    }
}