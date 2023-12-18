using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Authentication;

public class AuthOkMessage : BaseResultMessage
{
    [JsonProperty(PropertyName = "ha_version")]
    public string? HaVersion { get; set; }

    public AuthOkMessage()
        : base(HomeAssistantWsMessageTypes.AuthOk)
    {
    }

    protected override IEnumerable<ValidationResult> Validate()
    {
        foreach (var result in base.Validate())
        {
            yield return result;
        }
    }
}
