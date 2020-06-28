using Sholo.HomeAssistant.Client.Exceptions;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages
{
    public abstract class BaseCommandResult : BaseResultMessage
    {
        public long Id { get; set; }
        public bool? Success { get; set; }

        public void EnsureSuccessResult()
        {
            if (!(Success ?? true))
            {
                throw new HomeAssistantCommandException();
            }
        }

        protected BaseCommandResult(params HomeAssistantWsMessageType[] validMessageTypes)
            : base(validMessageTypes)
        {
        }
    }

    public abstract class BaseCommandResult<TResult> : BaseCommandResult
    {
        public TResult Result { get; set; }

        protected BaseCommandResult(params HomeAssistantWsMessageType[] validMessageTypes)
            : base(validMessageTypes)
        {
        }
    }
}
