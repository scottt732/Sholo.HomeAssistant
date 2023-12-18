using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Authentication;

public class AuthInvalidMessage : BaseResultMessage
{
    [JsonProperty(PropertyName = "message")]
    public string? Message { get; set; }

    public AuthInvalidMessage()
        : base(HomeAssistantWsMessageTypes.AuthInvalid)
    {
    }

    protected override IEnumerable<ValidationResult> Validate()
    {
        foreach (var result in base.Validate())
        {
            yield return result;
        }

        if (string.IsNullOrEmpty(Message))
        {
            yield return new ValidationResult($"The {nameof(Message)} field is required when the authentication request was invalid", new[] { nameof(Message) });
        }
    }
}
