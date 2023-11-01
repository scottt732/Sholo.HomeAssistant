using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

public class BinarySensorEntityDefinitionBuilder
    : BaseCoreSensorEntityDefinitionBuilder<BinarySensorEntityDefinitionBuilder, IBinarySensorEntityDefinition, BinarySensorEntityDefinition>,
        IBinarySensorEntityDefinitionBuilder<BinarySensorEntityDefinitionBuilder>
{
    public BinarySensorEntityDefinitionBuilder WithDeviceClass(BinarySensorDeviceClass deviceClass)
    {
        Target.DeviceClass = deviceClass;
        return this;
    }

    public BinarySensorEntityDefinitionBuilder WithExpireAfter(int expireAfterSeconds)
    {
        Target.ExpireAfter = expireAfterSeconds;
        return this;
    }

    public BinarySensorEntityDefinitionBuilder WithForceUpdate(bool forceUpdate = false)
    {
        Target.ForceUpdate = forceUpdate;
        return this;
    }

    public BinarySensorEntityDefinitionBuilder WithOffDelay(int delaySeconds)
    {
        Target.OffDelay = delaySeconds;
        return this;
    }

    public BinarySensorEntityDefinitionBuilder WithOnOffPayloads(string onPayload = "ON", string offPayload = "OFF")
    {
        Target.PayloadOn = onPayload;
        Target.PayloadOff = offPayload;
        return this;
    }
}
