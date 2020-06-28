using JetBrains.Annotations;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders
{
    [PublicAPI]
    public interface IStatefulEntityDefinitionBuilder<out TSelf, out TResult> : IEntityDefinitionBuilder<TSelf, TResult>
        where TSelf : IStatefulEntityDefinitionBuilder<TSelf, TResult>
        where TResult : IStatefulEntityDefinition
    {
        TSelf WithAvailabilityPayloads(string payloadAvailable = "online", string payloadNotAvailable = "offline");
        TSelf WithAvailabilityTopic(string availabilityTopic);
        TSelf WithJsonAttributes(string jsonAttributesTopic, string jsonAttributesTemplate);
        TSelf WithQos(MqttQualityOfServiceLevel qos = MqttQualityOfServiceLevel.AtMostOnce, bool retain = false);
        TSelf WithState(string stateTopic, string valueTemplate);
    }
}
