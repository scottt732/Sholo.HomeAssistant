using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.DeviceClasses;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public interface IBinarySensorEntityDefinitionBuilder<out TSelf> : ICoreSensorEntityDefinitionBuilder<TSelf, IBinarySensorEntityDefinition, BinarySensorDeviceClass>
    where TSelf : IBinarySensorEntityDefinitionBuilder<TSelf>
{
    TSelf WithOffDelay(int delaySeconds);
    TSelf WithOnOffPayloads(string onPayload = "ON", string offPayload = "OFF");
}
