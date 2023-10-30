using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages;

public abstract class BaseResultMessage : BaseMessage
{
    private HomeAssistantWsMessageType[] ValidMessageTypes { get; }

    protected BaseResultMessage(params HomeAssistantWsMessageType[] validMessageTypes)
    {
        ValidMessageTypes = validMessageTypes;
    }

    protected override IEnumerable<ValidationResult> Validate()
    {
        foreach (var result in base.Validate())
        {
            yield return result;
        }

        if (HaveMessageType && !ValidMessageTypes.Contains(MessageType))
        {
            yield return new ValidationResult($"The {nameof(MessageType)} '{MessageType}' is invalid. Expecting: {string.Join(", ", ValidMessageTypes)}");
        }
    }
}
