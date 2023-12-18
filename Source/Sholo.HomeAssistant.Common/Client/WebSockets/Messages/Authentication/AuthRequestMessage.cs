using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Authentication;

public class AuthRequestMessage : BaseMessage
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? AccessToken { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? ApiPasswordToken { get; set; }

    public AuthRequestMessage()
    {
        MessageType = HomeAssistantWsMessageTypes.Auth;
    }

    protected override IEnumerable<ValidationResult> Validate()
    {
        if (string.IsNullOrEmpty(AccessToken) && string.IsNullOrEmpty(ApiPasswordToken))
        {
            yield return new ValidationResult($"Either the '{nameof(AccessToken)}' or '{nameof(ApiPasswordToken)}' are required");
        }
        else if (!string.IsNullOrEmpty(AccessToken) && !string.IsNullOrEmpty(ApiPasswordToken))
        {
            yield return new ValidationResult($"Only one of '{nameof(AccessToken)}' and '{nameof(ApiPasswordToken)}' settings must be defined");
        }
    }
}
