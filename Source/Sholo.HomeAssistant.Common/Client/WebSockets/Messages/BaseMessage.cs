using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages;

public abstract class BaseMessage : IValidatableObject
{
    [JsonIgnore]
    protected bool HaveMessageType { get; private set; }

    private HomeAssistantWsMessageType? _messageType;

    [JsonProperty(PropertyName = "type")]
    [JsonConverter(typeof(HomeAssistantWsMessageTypeConverter))]
    public HomeAssistantWsMessageType MessageType
    {
        get => _messageType ?? string.Empty;
        set
        {
            _messageType = value;
            HaveMessageType = true;
        }
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!HaveMessageType)
        {
            yield return new ValidationResult($"The {nameof(MessageType)} was not set", new[] { nameof(MessageType) });
        }

        foreach (var result in Validate())
        {
            yield return result;
        }
    }

    protected virtual IEnumerable<ValidationResult> Validate()
    {
        yield break;
    }
}
