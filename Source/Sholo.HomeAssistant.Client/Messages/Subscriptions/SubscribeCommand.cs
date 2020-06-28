using Newtonsoft.Json;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.Subscriptions
{
    public class SubscribeCommand : BaseSubscriptionMessage
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EventType { get; }

        public SubscribeCommand()
        {
            MessageType = HomeAssistantWsMessageType.SubscribeEvents;
        }

        public SubscribeCommand(string eventType)
            : this()
        {
            EventType = eventType;
        }
    }
}
