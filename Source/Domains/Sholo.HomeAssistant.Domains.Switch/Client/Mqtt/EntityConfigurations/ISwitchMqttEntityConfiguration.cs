using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

public interface ISwitchMqttEntityConfiguration : IMqttStatefulEntityConfiguration<ISwitch, ISwitchEntityDefinition>
{
}
