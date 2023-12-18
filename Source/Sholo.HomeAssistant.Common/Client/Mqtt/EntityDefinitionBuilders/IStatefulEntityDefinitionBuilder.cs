using System;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public interface IStatefulEntityDefinitionBuilder<out TSelf, out TResult> : IEntityDefinitionBuilder<TSelf, TResult>
    where TSelf : IStatefulEntityDefinitionBuilder<TSelf, TResult>
    where TResult : IStatefulEntityDefinition
{
    TSelf WithAvailability(Action<IAvailabilitiesBuilder> config);
    TSelf WithAvailabilityMode(AvailabilityMode? availabilityMode);
    TSelf WithAvailabilityPayloads(string payloadAvailable = "online", string payloadNotAvailable = "offline");
    TSelf WithAvailabilityTopic(string availabilityTopic);
    TSelf WithJsonAttributes(string jsonAttributesTopic, string jsonAttributesTemplate);
    TSelf WithQos(QualityOfServiceLevel qos = QualityOfServiceLevel.AtMostOnce, bool retain = false);
    TSelf WithState(string stateTopic, string valueTemplate);
}
