using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public interface IBinarySensorEntityDefinition : ICoreSensorEntityDefinition
{
    /// <summary>
    /// Sets the class of the device, changing the device state and icon that is displayed
    /// on the frontend.
    /// </summary>
    BinarySensorDeviceClass? DeviceClass { get; }

    /// <summary>
    /// For sensors that only sends On state updates, this variable sets a delay in seconds
    /// after which the sensor state will be updated back to Off.
    /// </summary>
    int? OffDelay { get; }

    /// <summary>
    /// The payload that represents the off state.
    /// </summary>
    string PayloadOff { get; }

    /// <summary>
    /// The payload that represents the on state.
    /// </summary>
    string PayloadOn { get; }
}
