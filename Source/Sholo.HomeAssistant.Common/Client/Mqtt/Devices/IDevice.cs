using System;
using System.Collections.Generic;

namespace Sholo.HomeAssistant.Client.Mqtt.Devices;

[PublicAPI]
public interface IDevice
{
    /// <summary>
    /// Gets a link to the webpage that can manage the configuration of this device. Can
    /// be either an <code>http://</code>, <code>https://</code> or an internal
    /// <code>homeassistant://</code> URL.
    /// </summary>
    Uri? ConfigurationUrl { get; }

    /// <summary>
    /// Gets a list of connections of the device to the outside world as a list of tuples
    /// [connection_type, connection_identifier]. For example the MAC address of a network
    /// interface: 'connections': ['mac', '02:5b:26:a8:dc:12'].
    /// </summary>
    IReadOnlyDictionary<string, string>? Connections { get; }

    /// <summary>
    /// The hardware version of the device.
    /// </summary>
    string? HwVersion { get; }

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
    /// The suggested name for the area if the device isn't in one yet.
    /// </summary>
    string? SuggestedArea { get; }

    /// <summary>
    /// Gets the firmware version of the device.
    /// </summary>
    string SwVersion { get; }

    /// <summary>
    /// Identifier of a device that routes messages between this device and Home Assistant.
    /// Examples of such devices are hubs, or parent devices of a sub-device. This is used
    /// to show device topology in Home Assistant.
    /// </summary>
    string? ViaDevice { get; }
}
