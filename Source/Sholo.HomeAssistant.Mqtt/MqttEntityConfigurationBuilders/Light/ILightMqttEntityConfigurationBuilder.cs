using Sholo.HomeAssistant.Mqtt.Entities.Light;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Light;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Light;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Light;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Light
{
    public interface ILightMqttEntityConfigurationBuilder
        : IMqttStatefulEntityConfigurationBuilder<ILightMqttEntityConfigurationBuilder, ILight, ILightEntityDefinition, LightEntityDefinitionBuilder, ILightMqttEntityConfiguration>
    {
    }
}
