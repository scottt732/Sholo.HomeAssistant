using Sholo.HomeAssistant.Client.Messages;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Events
{
    public class EventMessage : BaseResultMessage, IEventMessage
    {
        public int Id { get; set; }

        protected EventMessage()
            : base(HomeAssistantWsMessageType.Event)
        {
        }
    }

    public class EventMessage<TPayload> : EventMessage, IEventMessage<TPayload>
    {
        public EventData<TPayload> Event { get; set; }
    }
}
