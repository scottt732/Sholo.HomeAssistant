using System;
using System.Collections.Generic;

namespace Sholo.HomeAssistant.Client.Mqtt.Devices;

public class DeviceBuilder : IDeviceBuilder
{
    private Uri? ConfigurationUrl { get; set; }
    private Dictionary<string, string> Connections { get; } = new();
    private string? HwVersion { get; set; }
    private List<string> Identifiers { get; } = new();
    private string? Manufacturer { get; set; }
    private string? Model { get; set; }
    private string? Name { get; set; }
    private string? SwVersion { get; set; }
    private string? SuggestedArea { get; set; }
    private string? ViaDevice { get; set; }

    public IDeviceBuilder WithConfigurationUrl(Uri? configurationUrl)
    {
        ConfigurationUrl = configurationUrl;
        return this;
    }

    public IDeviceBuilder WithConnection(string connectionType, string connectionIdentifier)
    {
        Connections.Add(connectionType, connectionIdentifier);
        return this;
    }

    public IDeviceBuilder WithHwVersion(string hwVersion)
    {
        HwVersion = hwVersion;
        return this;
    }

    public IDeviceBuilder WithIdentifier(string identifier)
    {
        Identifiers.Add(identifier);
        return this;
    }

    public IDeviceBuilder WithIdentifiers(params string[] identifiers)
    {
        Identifiers.AddRange(identifiers);
        return this;
    }

    public IDeviceBuilder WithManufacturer(string manufacturer)
    {
        Manufacturer = manufacturer;
        return this;
    }

    public IDeviceBuilder WithModel(string model)
    {
        Model = model;
        return this;
    }

    public IDeviceBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public IDeviceBuilder WithSuggestedArea(string? areaName)
    {
        SuggestedArea = areaName;
        return this;
    }

    public IDeviceBuilder WithSwVersion(string swVersion)
    {
        SwVersion = swVersion;
        return this;
    }

    public IDeviceBuilder WithViaDevice(string? viaDeviceId)
    {
        ViaDevice = viaDeviceId;
        return this;
    }

    public IDevice Build()
    {
        return new Device
        {
            ConfigurationUrl = ConfigurationUrl,
            Connections = Connections.Count > 0 ? Connections : null,
            HwVersion = HwVersion,
            Identifiers = Identifiers.Count > 0 ? Identifiers.ToArray() : null,
            Manufacturer = Manufacturer ?? throw new InvalidOperationException("Manufacturer is required"),
            Model = Model ?? throw new InvalidOperationException("Model is required"),
            Name = Name ?? throw new InvalidOperationException("Name is required"),
            SuggestedArea = SuggestedArea,
            SwVersion = SwVersion ?? throw new InvalidOperationException("SwVersion is required"),
            ViaDevice = ViaDevice
        };
    }
}
