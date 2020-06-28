using JetBrains.Annotations;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.DeviceTrigger;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.DeviceTrigger
{
    [PublicAPI]
    public interface IDeviceTriggerEntityDefinitionBuilder<TSelf> : IDefinitionBuilder<TSelf, IDeviceTriggerEntityDefinition>
        where TSelf : IDeviceTriggerEntityDefinitionBuilder<TSelf>
    {
        TSelf WithPayload(string payload);
        TSelf WithQos(MqttQualityOfServiceLevel qos);
        TSelf WithTopic(string topic);
        TSelf WithType(DeviceTriggerType type);
        TSelf WithSubType(DeviceTriggerSubType subtype);
    }
}
