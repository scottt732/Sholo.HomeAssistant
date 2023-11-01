namespace Sholo.HomeAssistant.Domains;

/// <summary>
/// Sensor device classes
/// </summary>
/// <remarks>
/// See <a href="https://www.home-assistant.io/integrations/sensor/#device-class">documentation</a>
/// </remarks>
[PublicAPI]
public enum SensorDeviceClass
{
    /// <summary>
    /// Generic sensor. This is the default and doesn't need to be set.
    /// </summary>
    [HomeAssistantMqttValue("")]
    None,

    /// <summary>
    /// battery: Percentage of battery that is left.
    /// </summary>
    [HomeAssistantMqttValue("battery")]
    Battery,

    /// <summary>
    /// humidity: Percentage of humidity in the air.
    /// </summary>
    [HomeAssistantMqttValue("humidity")]
    Humidity,

    /// <summary>
    /// illuminance: The current light level in lx or lm.
    /// </summary>
    [HomeAssistantMqttValue("illuminance")]
    Illuminance,

    /// <summary>
    /// signal_strength: Signal strength in dB or dBm.
    /// </summary>
    [HomeAssistantMqttValue("signal_strength")]
    SignalStrength,

    /// <summary>
    /// temperature: Temperature in °C or °F.
    /// </summary>
    [HomeAssistantMqttValue("temperature")]
    Temperature,

    /// <summary>
    /// power: Power in W or kW.
    /// </summary>
    [HomeAssistantMqttValue("power")]
    Power,

    /// <summary>
    /// pressure: Pressure in hPa or mbar.
    /// </summary>
    [HomeAssistantMqttValue("pressure")]
    Pressure,

    /// <summary>
    /// timestamp: Datetime object or timestamp string.
    /// </summary>
    [HomeAssistantMqttValue("timestamp")]
    Timestamp
}
