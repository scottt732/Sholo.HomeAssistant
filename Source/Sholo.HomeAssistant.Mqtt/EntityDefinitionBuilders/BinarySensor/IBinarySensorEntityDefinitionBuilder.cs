using JetBrains.Annotations;
using Sholo.HomeAssistant.DeviceClasses;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.BinarySensor;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.BinarySensor
{
    [PublicAPI]
    public interface IBinarySensorEntityDefinitionBuilder<out TSelf> : ICoreSensorEntityDefinitionBuilder<TSelf, IBinarySensorEntityDefinition, BinarySensorDeviceClass>
        where TSelf : IBinarySensorEntityDefinitionBuilder<TSelf>
    {
        TSelf WithOffDelay(int delaySeconds);
        TSelf WithOnOffPayloads(string onPayload = "ON", string offPayload = "OFF");
    }
}
