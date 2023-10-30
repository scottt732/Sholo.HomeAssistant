using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

public interface ISensorMqttEntityConfiguration : IMqttStatefulEntityConfiguration<ISensor, ISensorEntityDefinition>
{
}
