using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.WebSockets;

[PublicAPI]
[JsonConverter(typeof(HomeAssistantWsMessageTypeConverter))]
public sealed class HomeAssistantWsMessageType : IEquatable<HomeAssistantWsMessageType>, IEquatable<string>
{
    public string Path { get; }

    public HomeAssistantWsMessageType([CallerMemberName] string? path = null) => Path = path ?? throw new ArgumentNullException(nameof(path));

    public static HomeAssistantWsMessageType ToHomeAssistantWsMessageType(string input) => new(input);
    public static string ToString(HomeAssistantWsMessageType input) => input.ToString();

    public bool Equals(HomeAssistantWsMessageType? other) => other?.Path.Equals(Path, StringComparison.Ordinal) ?? false;
    public bool Equals(string? other) => other?.Equals(Path, StringComparison.Ordinal) ?? false;
    public override bool Equals(object? obj) => ReferenceEquals(this, obj) || (obj is HomeAssistantWsMessageType other && Equals(other));
    public override int GetHashCode() => Path.GetHashCode(StringComparison.Ordinal);

    public static implicit operator HomeAssistantWsMessageType(string input) => new(input);
    public static implicit operator string(HomeAssistantWsMessageType input) => input.ToString();

    public override string ToString() => Path;
}
