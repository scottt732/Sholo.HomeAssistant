using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public interface IDeviceTriggerEntityDefinitionBuilder<TSelf> : IDefinitionBuilder<TSelf, IDeviceTriggerEntityDefinition>
    where TSelf : IDeviceTriggerEntityDefinitionBuilder<TSelf>
{
    TSelf WithPayload(string payload);
    TSelf WithQos(QualityOfServiceLevel qos);
    TSelf WithTopic(string topic);
    TSelf WithType(DeviceTriggerType type);
    TSelf WithSubType(DeviceTriggerSubType subtype);
}
