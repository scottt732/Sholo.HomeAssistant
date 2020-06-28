using Sholo.HomeAssistant.Mqtt.Entities.Cover;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Cover;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Cover;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Cover;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Cover
{
    public interface ICoverMqttEntityConfigurationBuilder
        : IMqttStatefulEntityConfigurationBuilder<ICoverMqttEntityConfigurationBuilder, ICover, ICoverEntityDefinition, CoverEntityDefinitionBuilder, ICoverMqttEntityConfiguration>
    {
    }
}
