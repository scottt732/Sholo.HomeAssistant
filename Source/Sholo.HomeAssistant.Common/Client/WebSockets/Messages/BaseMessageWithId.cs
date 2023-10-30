namespace Sholo.HomeAssistant.Client.WebSockets.Messages;

public abstract class BaseMessageWithId : BaseMessage
{
    public long Id { get; set; }
}
