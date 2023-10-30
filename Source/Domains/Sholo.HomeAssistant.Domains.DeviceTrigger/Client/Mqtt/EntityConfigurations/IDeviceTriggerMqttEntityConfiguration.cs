using Sholo.HomeAssistant.Client.Mqtt;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

public interface IDeviceTriggerMqttEntityConfiguration : IMqttEntityConfiguration<IDeviceTrigger, IDeviceTriggerEntityDefinition>
{
}
