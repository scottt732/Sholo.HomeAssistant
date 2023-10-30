namespace Sholo.HomeAssistant.DeviceClasses;

/// <summary>
/// Binary Sensor device classes
/// </summary>
/// <remarks>
/// See <a href="https://www.home-assistant.io/integrations/binary_sensor/#device-class">documentation</a>
/// </remarks>
[PublicAPI]
public enum BinarySensorDeviceClass
{
    /// <summary>
    /// None: Generic on/off. This is the default and doesn't need to be set.
    /// </summary>
    [HomeAssistantMqttValue("")]
    None,

    /// <summary>
    /// battery: on means low, off means normal
    /// </summary>
    [HomeAssistantMqttValue("battery")]
    Battery,

    /// <summary>
    /// cold: on means cold, off means normal
    /// </summary>
    [HomeAssistantMqttValue("cold")]
    Cold,

    /// <summary>
    /// connectivity: on means connected, off means disconnected
    /// </summary>
    [HomeAssistantMqttValue("connectivity")]
    Connectivity,

    /// <summary>
    /// door: on means open, off means closed
    /// </summary>
    [HomeAssistantMqttValue("door")]
    Door,

    /// <summary>
    /// garage_door: on means open, off means closed
    /// </summary>
    [HomeAssistantMqttValue("garage_door")]
    GarageDoor,

    /// <summary>
    /// gas: on means gas detected, off means no gas (clear)
    /// </summary>
    [HomeAssistantMqttValue("gas")]
    Gas,

    /// <summary>
    /// heat: on means hot, off means normal
    /// </summary>
    [HomeAssistantMqttValue("heat")]
    Heat,

    /// <summary>
    /// light: on means light detected, off means no light
    /// </summary>
    [HomeAssistantMqttValue("light")]
    Light,

    /// <summary>
    /// lock: on means open (unlocked), off means closed (locked)
    /// </summary>
    [HomeAssistantMqttValue("lock")]
    Lock,

    /// <summary>
    /// moisture: on means moisture detected (wet), off means no moisture (dry)
    /// </summary>
    [HomeAssistantMqttValue("moisture")]
    Moisture,

    /// <summary>
    /// motion: on means motion detected, off means no motion (clear)
    /// </summary>
    [HomeAssistantMqttValue("motion")]
    Motion,

    /// <summary>
    /// moving: on means moving, off means not moving (stopped)
    /// </summary>
    [HomeAssistantMqttValue("moving")]
    Moving,

    /// <summary>
    /// occupancy: on means occupied, off means not occupied (clear)
    /// </summary>
    [HomeAssistantMqttValue("occupancy")]
    Occupancy,

    /// <summary>
    /// opening: on means open, off means closed
    /// </summary>
    [HomeAssistantMqttValue("opening")]
    Opening,

    /// <summary>
    /// plug: on means device is plugged in, off means device is unplugged
    /// </summary>
    [HomeAssistantMqttValue("plug")]
    Plug,

    /// <summary>
    /// power: on means power detected, off means no power
    /// </summary>
    [HomeAssistantMqttValue("power")]
    Power,

    /// <summary>
    /// presence: on means home, off means away
    /// </summary>
    [HomeAssistantMqttValue("presence")]
    Presence,

    /// <summary>
    /// problem: on means problem detected, off means no problem (OK)
    /// </summary>
    [HomeAssistantMqttValue("problem")]
    Problem,

    /// <summary>
    /// safety: on means unsafe, off means safe
    /// </summary>
    [HomeAssistantMqttValue("safety")]
    Safety,

    /// <summary>
    /// smoke: on means smoke detected, off means no smoke(clear)
    /// </summary>
    [HomeAssistantMqttValue("smoke")]
    Smoke,

    /// <summary>
    /// sound: on means sound detected, off means no sound(clear)
    /// </summary>
    [HomeAssistantMqttValue("sound")]
    Sound,

    /// <summary>
    /// vibration: on means vibration detected, off means no vibration(clear)
    /// </summary>
    [HomeAssistantMqttValue("vibration")]
    Vibration,

    /// <summary>
    /// window: on means open, off means closed
    /// </summary>
    [HomeAssistantMqttValue("window")]
    Window
}
