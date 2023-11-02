using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

[PublicAPI]
public interface IButtonMqttEntityConfiguration : IMqttStatefulEntityConfiguration<IButton, IButtonEntityDefinition>
{
}
