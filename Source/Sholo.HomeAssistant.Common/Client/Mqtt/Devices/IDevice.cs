using System.Collections.Generic;

namespace Sholo.HomeAssistant.Client.Mqtt.Devices;

[PublicAPI]
public interface IDevice
{
    /// <summary>
    /// Gets a list of connections of the device to the outside world as a list of tuples
    /// [connection_type, connection_identifier]. For example the MAC address of a network
    /// interface: 'connections': ['mac', '02:5b:26:a8:dc:12'].
    /// </summary>
    IDictionary<string, string>? Connections { get; }

    /// <summary>
    /// Gets a list of IDs that uniquely identify the device. For example a serial number.
    /// </summary>
    string[]? Identifiers { get; }

    /// <summary>
    /// Gets the manufacturer of the device.
    /// </summary>
    string Manufacturer { get; }

    /// <summary>
    /// Gets the model of the device.
    /// </summary>
    string Model { get; }

    /// <summary>
    /// Gets the name of the device.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the firmware version of the device.
    /// </summary>
    string SwVersion { get; }
}
