using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

public interface ILightMqttEntityConfiguration : IMqttStatefulEntityConfiguration<ILight, ILightEntityDefinition>
{
}
