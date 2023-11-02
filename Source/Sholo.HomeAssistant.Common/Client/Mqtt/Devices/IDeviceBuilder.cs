namespace Sholo.HomeAssistant.Client.Mqtt.Devices;

[PublicAPI]
public interface IDeviceBuilder
{
    /// <summary>
    /// (Optional) Adds a connection of the device to the outside world.  For example the
    /// MAC address of a network interface: 'connections': ['mac', '02:5b:26:a8:dc:12'].
    /// </summary>
    /// <param name="connectionType">A Connection type (example 'mac')</param>
    /// <param name="connectionIdentifier">A connection identifier (example '02:5b:26:a8:dc:12')</param>
    /// <returns>The <see cref="IDeviceBuilder" /></returns>
    IDeviceBuilder WithConnection(string connectionType, string connectionIdentifier);

    /// <summary>
    /// (Optional) Adds an ID that uniquely identify the device. For example a serial number.
    /// </summary>
    /// <param name="identifier">An ID that uniquely identify the device</param>
    /// <returns>The <see cref="IDeviceBuilder" /></returns>
    IDeviceBuilder WithIdentifier(string identifier);

    /// <summary>
    /// (Optional) The manufacturer of the device.
    /// </summary>
    /// <param name="manufacturer">The manufacturer of the device</param>
    /// <returns>The <see cref="IDeviceBuilder" /></returns>
    IDeviceBuilder WithManufacturer(string manufacturer);

    /// <summary>
    /// (Optional) The model of the device.
    /// </summary>
    /// <param name="model">The model of the device</param>
    /// <returns>The <see cref="IDeviceBuilder" /></returns>
    IDeviceBuilder WithModel(string model);

    /// <summary>
    /// (Optional) The name of the device.
    /// </summary>
    /// <param name="name">The name of the device</param>
    /// <returns>The <see cref="IDeviceBuilder" /></returns>
    IDeviceBuilder WithName(string name);

    /// <summary>
    /// (Optional) The firmware version of the device.
    /// </summary>
    /// <param name="swVersion">The firmware version of the device</param>
    /// <returns>The <see cref="IDeviceBuilder" /></returns>
    IDeviceBuilder WithSwVersion(string swVersion);

    /// <summary>
    /// (Optional) Identifier of a device that routes messages between this device and
    /// Home Assistant. Examples of such devices are hubs, or parent devices of a
    /// sub-device. This is used to show device topology in Home Assistant.
    /// </summary>
    /// <param name="viaDeviceId">The identifier of the parent device</param>
    /// <returns>The <see cref="IDeviceBuilder" /></returns>
    IDeviceBuilder WithViaDevice(string? viaDeviceId);

    /// <summary>
    /// The suggested name for the area where the device is located.
    /// </summary>
    /// <param name="areaName">The suggested name of the area where the device is located</param>
    /// <returns>The <see cref="IDeviceBuilder" /></returns>
    IDeviceBuilder WithSuggestedArea(string? areaName);

    /// <summary>
    /// Builds the <see cref="IDevice" /> using the configured parameters
    /// </summary>
    /// <returns>An <see cref="IDevice" /></returns>
    IDevice Build();
}
