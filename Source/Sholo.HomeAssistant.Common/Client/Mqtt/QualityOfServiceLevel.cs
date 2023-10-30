namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public enum QualityOfServiceLevel
{
    /// <summary>
    /// At most once (best effort, default) = 0
    /// </summary>
    AtMostOnce = 0x00,

    /// <summary>
    /// At least once = 1
    /// </summary>
    AtLeastOnce = 0x01,

    /// <summary>
    /// Exactly once = 2
    /// </summary>
    ExactlyOnce = 0x02
}
