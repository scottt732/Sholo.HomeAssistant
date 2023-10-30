using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

public class DeviceTriggerEntityDefinitionBuilder : BaseEntityDefinitionBuilder<DeviceTriggerEntityDefinitionBuilder, IDeviceTriggerEntityDefinition, DeviceTriggerEntityDefinition>, IDeviceTriggerEntityDefinitionBuilder<DeviceTriggerEntityDefinitionBuilder>
{
    public DeviceTriggerEntityDefinitionBuilder()
    {
        Target.AutomationType = "trigger";
    }

    public DeviceTriggerEntityDefinitionBuilder WithPayload(string payload)
    {
        Target.Payload = payload;
        return this;
    }

    public DeviceTriggerEntityDefinitionBuilder WithQos(QualityOfServiceLevel qos)
    {
        Target.Qos = qos;
        return this;
    }

    public DeviceTriggerEntityDefinitionBuilder WithTopic(string topic)
    {
        Target.Topic = topic;
        return this;
    }

    public DeviceTriggerEntityDefinitionBuilder WithType(DeviceTriggerType type)
    {
        Target.Type = type;
        return this;
    }

    public DeviceTriggerEntityDefinitionBuilder WithSubType(DeviceTriggerSubType subtype)
    {
        Target.Subtype = subtype;
        return this;
    }
}
