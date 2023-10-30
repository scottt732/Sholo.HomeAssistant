using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

public class CameraEntityDefinitionBuilder
    : BaseEntityDefinitionBuilder<CameraEntityDefinitionBuilder, ICameraEntityDefinition, CameraEntityDefinition>,
        ICameraEntityDefinitionBuilder<CameraEntityDefinitionBuilder>
{
    public CameraEntityDefinitionBuilder WithTopic(string topic)
    {
        Target.Topic = topic;
        return this;
    }
}
