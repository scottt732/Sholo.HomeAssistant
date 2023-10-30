using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

public interface IFanMqttEntityConfiguration : IMqttStatefulEntityConfiguration<IFan, IFanEntityDefinition>
{
}
