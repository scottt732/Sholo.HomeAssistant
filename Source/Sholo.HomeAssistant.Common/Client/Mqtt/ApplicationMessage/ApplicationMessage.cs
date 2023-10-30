using System;
using System.Collections.Generic;

namespace Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;

/// <inheritdoc />>
internal sealed class ApplicationMessage : IApplicationMessage
{
    /// <inheritdoc />>
    public string? ContentType { get; init; }

    /// <inheritdoc />>
    public byte[]? CorrelationData { get; init; }

    /// <inheritdoc />>
    public uint MessageExpiryInterval { get; init; }

    /// <inheritdoc />>
    public ArraySegment<byte>? Payload { get; init; }

    /// <inheritdoc />>
    public PayloadFormatIndicator PayloadFormatIndicator { get; init; }

    /// <inheritdoc />>
    public QualityOfServiceLevel QualityOfServiceLevel { get; init; }

    /// <inheritdoc />>
    public string? ResponseTopic { get; init; }

    /// <inheritdoc />>
    public bool Retain { get; init; }

    /// <inheritdoc />>
    public uint[]? SubscriptionIdentifiers { get; init; }

    /// <inheritdoc />>
    public string Topic { get; init; } = null!;

    /// <inheritdoc />>
    public ushort TopicAlias { get; init; }

    /// <inheritdoc />>
    public KeyValuePair<string, string>[]? UserProperties { get; init; }
}
