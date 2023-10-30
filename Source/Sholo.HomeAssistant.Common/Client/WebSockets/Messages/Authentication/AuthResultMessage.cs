using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Authentication;

public class AuthResultMessage : BaseResultMessage
{
    public string? Message { get; set; }

    public AuthResultMessage()
        : base(HomeAssistantWsMessageType.AuthOk, HomeAssistantWsMessageType.AuthInvalid)
    {
    }

    protected override IEnumerable<ValidationResult> Validate()
    {
        foreach (var result in base.Validate())
        {
            yield return result;
        }

        if (HaveMessageType && MessageType == HomeAssistantWsMessageType.AuthInvalid)
        {
            if (string.IsNullOrEmpty(Message))
            {
                yield return new ValidationResult($"The {nameof(Message)} field is required when the authentication request was invalid", new[] { nameof(Message) });
            }
        }
        else if (HaveMessageType && MessageType != HomeAssistantWsMessageType.AuthInvalid)
        {
            if (!string.IsNullOrEmpty(Message))
            {
                yield return new ValidationResult($"The {nameof(Message)} field is only expected when the authentication request was invalid", new[] { nameof(Message) });
            }
        }
    }
}
