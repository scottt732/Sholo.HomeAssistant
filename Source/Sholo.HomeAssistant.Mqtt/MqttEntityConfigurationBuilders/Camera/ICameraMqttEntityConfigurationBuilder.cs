using Sholo.HomeAssistant.Mqtt.Entities.Camera;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Camera;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Camera;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Camera;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Camera
{
    public interface ICameraMqttEntityConfigurationBuilder
        : IMqttEntityConfigurationBuilder<ICameraMqttEntityConfigurationBuilder, ICamera, ICameraEntityDefinition, CameraEntityDefinitionBuilder, ICameraMqttEntityConfiguration>
    {
    }
}
