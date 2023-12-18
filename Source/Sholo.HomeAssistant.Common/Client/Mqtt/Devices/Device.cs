using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sholo.HomeAssistant.Serialization;

namespace Sholo.HomeAssistant.Client.Mqtt.Devices;

public sealed class Device : IDevice
{
    public Uri? ConfigurationUrl { get; init; }

    [JsonConverter(typeof(DictionaryAsArrayOfArraysConverter<string, string>))]
    public IReadOnlyDictionary<string, string>? Connections { get; init; }

    public string? HwVersion { get; init; }
    public string[]? Identifiers { get; init; }
    public string Manufacturer { get; init; } = null!;
    public string Model { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string? SuggestedArea { get; init; }
    public string SwVersion { get; init; } = null!;
    public string? ViaDevice { get; init; }
}
