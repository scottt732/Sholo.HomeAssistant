using System.Collections.Generic;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

public interface IAvailabilitiesBuilder
{
    IAvailabilitiesBuilder Add(string topic, string? payloadAvailable = "online", string? payloadNotAvailable = "offline", string? valueTemplate = null);
}

public class AvailabilitiesBuilder : IAvailabilitiesBuilder
{
    private List<Availability> Availabilities { get; } = new();

    public IAvailabilitiesBuilder Add(string topic, string? payloadAvailable = "online", string? payloadNotAvailable = "offline", string? valueTemplate = null)
    {
        MqttTopicValidator.ThrowIfInvalid(topic);

        Availabilities.Add(
            new Availability
            {
                Topic = topic,
                PayloadAvailable = payloadAvailable,
                PayloadNotAvailable = payloadNotAvailable,
                ValueTemplate = valueTemplate
            });

        return this;
    }

    public Availability[] Build()
    {
        return Availabilities.ToArray();
    }
}
