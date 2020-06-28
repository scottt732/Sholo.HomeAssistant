using Sholo.HomeAssistant.Mqtt.Entities.Camera;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Camera;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Camera
{
    public interface ICameraMqttEntityConfiguration : IMqttEntityConfiguration<ICamera, ICameraEntityDefinition>
    {
    }
}
