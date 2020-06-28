using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Camera;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Camera
{
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
}
