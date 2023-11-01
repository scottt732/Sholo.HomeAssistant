namespace Sholo.HomeAssistant.Domains;

/// <summary>
/// Sensor device classes
/// </summary>
/// <remarks>
/// See <a href="https://www.home-assistant.io/integrations/cover/#device-class">documentation</a>
/// </remarks>
[PublicAPI]
public enum CoverDeviceClass
{
    /// <summary>
    /// None: Generic cover. This is the default and doesn't need to be set.
    /// </summary>
    [HomeAssistantMqttValue("")]
    None,

    /// <summary>
    /// awning: Control of an awning, such as an exterior retractable window, door, or patio cover.
    /// </summary>
    [HomeAssistantMqttValue("awning")]
    Awning,

    /// <summary>
    /// blind: Control of blinds, which are linked slats that expand or collapse to cover an opening or may be tilted to partially covering an opening, such as window blinds.
    /// </summary>
    [HomeAssistantMqttValue("blind")]
    Blind,

    /// <summary>
    /// curtain: Control of curtains or drapes, which is often fabric hung above a window or door that can be drawn open.
    /// </summary>
    [HomeAssistantMqttValue("curtain")]
    Curtian,

    /// <summary>
    /// damper: Control of a mechanical damper that reduces airflow, sound, or light.
    /// </summary>
    [HomeAssistantMqttValue("damper")]
    Damper,

    /// <summary>
    /// door: Control of a door or gate that provides access to an area.
    /// </summary>
    [HomeAssistantMqttValue("door")]
    Door,

    /// <summary>
    /// garage: Control of a garage door that provides access to a garage.
    /// </summary>
    [HomeAssistantMqttValue("garage")]
    Garage,

    /// <summary>
    /// shade: Control of shades, which are a continuous plane of material or connected cells that expanded or collapsed over an opening, such as window shades.
    /// </summary>
    [HomeAssistantMqttValue("shade")]
    Shade,

    /// <summary>
    /// shutter: Control of shutters, which are linked slats that swing out/in to covering an opening or may be tilted to partially cover an opening, such as indoor or exterior window shutters.
    /// </summary>
    [HomeAssistantMqttValue("shutter")]
    Shutter,

    /// <summary>
    /// window: Control of a physical window that opens and closes or may tilt.
    /// </summary>
    [HomeAssistantMqttValue("window")]
    Window
}
