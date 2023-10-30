using Sholo.HomeAssistant.DeviceClasses;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public class BinarySensorEntityDefinition : BaseCoreSensorEntityDefinition, IBinarySensorEntityDefinition
{
    public BinarySensorDeviceClass? DeviceClass { get; internal set; }
    public int? OffDelay { get; internal set; }
    public string PayloadOff { get; internal set; } = null!;
    public string PayloadOn { get; internal set; } = null!;
}
