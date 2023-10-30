using System;
using System.Collections.Generic;
using System.Linq;

namespace Sholo.HomeAssistant.Client.Mqtt.Devices;

public class DeviceBuilder : IDeviceBuilder
{
    private readonly Device _device = new();

    public IDeviceBuilder WithConnection(string connectionType, string connectionIdentifier)
    {
        _device.AddConnection(connectionType, connectionIdentifier);
        return this;
    }

    public IDeviceBuilder WithIdentifier(string identifier)
    {
        _device.AddIdentifier(identifier);
        return this;
    }

    public IDeviceBuilder WithManufacturer(string manufacturer)
    {
        _device.Manufacturer = manufacturer;
        return this;
    }

    public IDeviceBuilder WithModel(string model)
    {
        _device.Model = model;
        return this;
    }

    public IDeviceBuilder WithName(string name)
    {
        _device.Name = name;
        return this;
    }

    public IDeviceBuilder WithSwVersion(string swVersion)
    {
        _device.SwVersion = swVersion;
        return this;
    }

    public IDevice Build() => _device;

    private sealed class Device : IDevice
    {
        public IDictionary<string, string>? Connections => _connections.Count > 0 ? _connections : null;
        public string[]? Identifiers => _identifiers.Count > 0 ? _identifiers.ToArray() : null;
        public string Manufacturer { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string SwVersion { get; set; } = null!;

        private readonly IDictionary<string, string> _connections = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<string> _identifiers = new();

        public void AddIdentifier(string identifier)
        {
            _identifiers.Add(identifier);
        }

        public void AddConnection(string connectionType, string connectionIdentifier)
        {
            _connections.Add(connectionType, connectionIdentifier);
        }
    }
}
