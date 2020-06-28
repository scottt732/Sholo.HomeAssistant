namespace Sholo.HomeAssistant.Client.Messages
{
    public abstract class BaseMessageWithId : BaseMessage
    {
        public long Id { get; set; }
    }
}