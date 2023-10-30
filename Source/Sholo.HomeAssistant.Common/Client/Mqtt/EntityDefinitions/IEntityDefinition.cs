using Sholo.HomeAssistant.Client.Mqtt.Devices;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public interface IEntityDefinition : IDefinition
{
    /// <summary>
    /// Information about the device this item is a part of to tie it into the device registry.
    /// Only works through MQTT discovery and when unique_id is set.
    /// </summary>
    IDevice Device { get; }

    /// <summary>
    /// The name of the device
    /// </summary>
    string Name { get; }

    /// <summary>
    /// An ID that uniquely identifies this device. If two devices have the same unique ID Home
    /// Assistant will raise an exception.
    /// </summary>
    string UniqueId { get; }
}
