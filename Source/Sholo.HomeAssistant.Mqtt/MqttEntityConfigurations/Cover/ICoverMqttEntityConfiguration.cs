using Sholo.HomeAssistant.Mqtt.Entities.Cover;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Cover;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Cover
{
    public interface ICoverMqttEntityConfiguration : IMqttStatefulEntityConfiguration<ICover, ICoverEntityDefinition>
    {
    }
}
