namespace Sholo.HomeAssistant.Domains;

/// <summary>
/// Media Player device classes
/// </summary>
/// <remarks>
/// See <a href="https://www.home-assistant.io/integrations/media_player/#device-class">documentation</a>
/// </remarks>
[PublicAPI]
public enum MediaPlayerDeviceClass
{
    /// <summary>
    /// None: Generic cover. This is the default and doesn't need to be set.
    /// </summary>
    [HomeAssistantMqttValue("")]
    None,

    /// <summary>
    /// tv: Device is a television type device.
    /// </summary>
    [HomeAssistantMqttValue("tv")]
    Tv,

    /// <summary>
    /// speaker: Device is speaker or stereo type device.
    /// </summary>
    [HomeAssistantMqttValue("speaker")]
    Speaker
}
