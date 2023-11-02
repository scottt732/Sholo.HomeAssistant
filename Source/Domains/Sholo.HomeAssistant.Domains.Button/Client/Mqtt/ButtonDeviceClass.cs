namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public enum ButtonDeviceClass
{
    /// <summary>
    /// None: Generic button. This is the default and doesn't need to be set.
    /// </summary>
    [HomeAssistantMqttValue("")]
    None,

    /// <summary>
    /// identify: The button is used to identify a device.
    /// </summary>
    [HomeAssistantMqttValue("identify")]
    Identify,

    /// <summary>
    /// restart: The button restarts the device.
    /// </summary>
    [HomeAssistantMqttValue("restart")]
    Restart,

    /// <summary>
    /// update: The button updates the software of the device.
    /// </summary>
    [HomeAssistantMqttValue("update")]
    Update
}
