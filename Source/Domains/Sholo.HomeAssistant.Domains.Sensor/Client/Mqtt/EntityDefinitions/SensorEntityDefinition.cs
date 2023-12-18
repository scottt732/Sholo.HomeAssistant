using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public class SensorEntityDefinition : BaseCoreSensorEntityDefinition, ISensorEntityDefinition
{
    public SensorDeviceClass? DeviceClass { get; internal set; }
    public string Icon { get; internal set; } = null!;
    public string UnitOfMeasurement { get; internal set; } = null!;
    public SensorStateClass? StateClass { get; internal set; }
    public DateTime? LastReset { get; internal set; }
    public string? LastResetValueTemplate { get; internal set; }
    public ushort? SuggestedDisplayPrecision { get; internal set; }
}
