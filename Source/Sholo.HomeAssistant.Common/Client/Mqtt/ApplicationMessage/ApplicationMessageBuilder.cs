using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;

/// <inheritdoc />
internal sealed class ApplicationMessageBuilder : IApplicationMessageBuilder
{
    private static readonly ArraySegment<byte> EmptyBuffer = new(Array.Empty<byte>(), 0, 0);

    private string? ContentType { get; set; }
    private byte[]? CorrelationData { get; set; }
    private uint MessageExpiryInterval { get; set; }
    private PayloadFormatIndicator PayloadFormatIndicator { get; set; }
    private ArraySegment<byte>? PayloadSegment { get; set; }
    private QualityOfServiceLevel QualityOfServiceLevel { get; set; } = QualityOfServiceLevel.AtMostOnce;
    private string? ResponseTopic { get; set; }
    private bool? Retain { get; set; }
    private List<uint>? SubscriptionIdentifiers { get; set; }
    private string? Topic { get; set; }
    private ushort TopicAlias { get; set; }
    private List<KeyValuePair<string, string>>? UserProperties { get; set; }

    public IApplicationMessage Build()
    {
        if (TopicAlias == 0 && string.IsNullOrEmpty(Topic))
        {
            throw new ArgumentException($"{nameof(IApplicationMessage.Topic)} or {nameof(IApplicationMessage.TopicAlias)} is not set.");
        }

        var applicationMessage = new ApplicationMessage
        {
            Topic = Topic ?? throw new ArgumentException(nameof(Topic)),
            Payload = PayloadSegment ?? throw new ArgumentNullException(nameof(PayloadSegment)),
            QualityOfServiceLevel = QualityOfServiceLevel,
            Retain = Retain ?? true,
            ContentType = ContentType,
            ResponseTopic = ResponseTopic,
            CorrelationData = CorrelationData,
            TopicAlias = TopicAlias,
            SubscriptionIdentifiers = SubscriptionIdentifiers?.ToArray(),
            MessageExpiryInterval = MessageExpiryInterval,
            PayloadFormatIndicator = PayloadFormatIndicator,
            UserProperties = UserProperties?.ToArray()
        };

        return applicationMessage;
    }

    /// <summary>
    ///     Adds the content type to the message.
    ///     <remarks>MQTT 5.0.0+ feature.</remarks>
    /// </summary>
    /// <param name="contentType">Content type of the message payload</param>
    /// <returns>The <see cref="IApplicationMessageBuilder" /> being built</returns>
    public IApplicationMessageBuilder WithContentType(string contentType)
    {
        ContentType = contentType;
        return this;
    }

    /// <summary>
    ///     Adds the correlation data to the message.
    ///     <remarks>MQTT 5.0.0+ feature.</remarks>
    /// </summary>
    /// <param name="correlationData">MQTT correlation data</param>
    /// <returns>The <see cref="IApplicationMessageBuilder" /> being built</returns>
    public IApplicationMessageBuilder WithCorrelationData(byte[] correlationData)
    {
        CorrelationData = correlationData;
        return this;
    }

    /// <summary>
    ///     Adds the message expiry interval in seconds to the message.
    ///     <remarks>MQTT 5.0.0+ feature.</remarks>
    /// </summary>
    /// <param name="messageExpiryInterval">Indicates the time at which the message expires (in seconds)</param>
    /// <returns>The <see cref="IApplicationMessageBuilder" /> being built</returns>
    public IApplicationMessageBuilder WithMessageExpiryInterval(uint messageExpiryInterval)
    {
        MessageExpiryInterval = messageExpiryInterval;
        return this;
    }

    public IApplicationMessageBuilder WithPayload(byte[]? payload)
    {
        PayloadSegment = payload == null || payload.Length == 0 ? EmptyBuffer : new ArraySegment<byte>(payload);
        return this;
    }

    public IApplicationMessageBuilder WithPayload(ArraySegment<byte>? payloadSegment)
    {
        PayloadSegment = payloadSegment;
        return this;
    }

    public IApplicationMessageBuilder WithPayload(IEnumerable<byte>? payload)
    {
        if (payload == null)
        {
            return WithPayload(default(byte[]));
        }

        if (payload is byte[] byteArray)
        {
            return WithPayload(byteArray);
        }

        if (payload is ArraySegment<byte> arraySegment)
        {
            return WithPayloadSegment(arraySegment);
        }

        return WithPayload(payload.ToArray());
    }

    public IApplicationMessageBuilder WithPayload(Stream? payload)
    {
        return payload == null ? WithPayload(default(byte[])) : WithPayload(payload, payload.Length - payload.Position);
    }

    public IApplicationMessageBuilder WithPayload(Stream? payload, long length)
    {
        if (payload == null || length == 0)
        {
            return WithPayload(default(byte[]));
        }

        var payloadBuffer = new byte[length];
        var totalRead = 0;
        do
        {
            var bytesRead = payload.Read(payloadBuffer, totalRead, payloadBuffer.Length - totalRead);
            if (bytesRead == 0)
            {
                break;
            }

            totalRead += bytesRead;
        }
        while (totalRead < length);

        return WithPayload(payloadBuffer);
    }

    public IApplicationMessageBuilder WithPayload(string? payload)
    {
        if (string.IsNullOrEmpty(payload))
        {
            return WithPayload(default(byte[]));
        }

        var payloadBuffer = Encoding.UTF8.GetBytes(payload);
        return WithPayload(payloadBuffer);
    }

    /// <summary>
    ///     Adds the payload format indicator to the message.
    ///     <remarks>MQTT 5.0.0+ feature.</remarks>
    /// </summary>
    /// <param name="payloadFormatIndicator">Indicates whether the payload contains character data</param>
    /// <returns>The <see cref="IApplicationMessageBuilder" /> being built</returns>
    public IApplicationMessageBuilder WithPayloadFormatIndicator(PayloadFormatIndicator payloadFormatIndicator)
    {
        PayloadFormatIndicator = payloadFormatIndicator;
        return this;
    }

    public IApplicationMessageBuilder WithPayloadSegment(ArraySegment<byte> payloadSegment)
    {
        PayloadSegment = payloadSegment;
        return this;
    }

    public IApplicationMessageBuilder WithPayloadSegment(ReadOnlyMemory<byte> payloadSegment)
    {
        return MemoryMarshal.TryGetArray(payloadSegment, out var segment) ? WithPayloadSegment(segment) : WithPayload(payloadSegment.ToArray());
    }

    /// <summary>
    ///     The quality of service level.
    ///     The Quality of Service (QoS) level is an agreement between the sender of a message and the receiver of a message
    ///     that defines the guarantee of delivery for a specific message.
    ///     There are 3 QoS levels in MQTT:
    ///     - At most once  (0): Message gets delivered no time, once or multiple times.
    ///     - At least once (1): Message gets delivered at least once (one time or more often).
    ///     - Exactly once  (2): Message gets delivered exactly once (It's ensured that the message only comes once).
    /// </summary>
    /// <param name="qualityOfServiceLevel">The quality of service level for the message being published</param>
    /// <returns>The <see cref="IApplicationMessageBuilder" /> being built</returns>
    public IApplicationMessageBuilder WithQualityOfServiceLevel(QualityOfServiceLevel qualityOfServiceLevel)
    {
        QualityOfServiceLevel = qualityOfServiceLevel;
        return this;
    }

    /// <summary>
    ///     Adds the response topic to the message.
    ///     <remarks>MQTT 5.0.0+ feature.</remarks>
    /// </summary>
    /// <param name="responseTopic">The topic on which a response is expected</param>
    /// <returns>The <see cref="IApplicationMessageBuilder" /> being built</returns>
    public IApplicationMessageBuilder WithResponseTopic(string responseTopic)
    {
        ResponseTopic = responseTopic;
        return this;
    }

    /// <summary>
    ///     A value indicating whether the message should be retained or not.
    ///     A retained message is a normal MQTT message with the retained flag set to true.
    ///     The broker stores the last retained message and the corresponding QoS for that topic.
    /// </summary>
    /// <param name="value">Boolean value indicating whether the message should be retained by the broker</param>
    /// <returns>The <see cref="IApplicationMessageBuilder" /> being built</returns>
    public IApplicationMessageBuilder WithRetainFlag(bool? value = null)
    {
        Retain = value;
        return this;
    }

    /// <summary>
    ///     Adds the subscription identifier to the message.
    ///     <remarks>MQTT 5.0.0+ feature.</remarks>
    /// </summary>
    /// <param name="subscriptionIdentifier">The MQTT subscription identifier</param>
    /// <returns>The <see cref="IApplicationMessageBuilder" /> being built</returns>
    public IApplicationMessageBuilder WithSubscriptionIdentifier(uint subscriptionIdentifier)
    {
        SubscriptionIdentifiers ??= new List<uint>();
        SubscriptionIdentifiers.Add(subscriptionIdentifier);
        return this;
    }

    /// <summary>
    ///     The MQTT topic.
    ///     In MQTT, the word topic refers to an UTF-8 string that the broker uses to filter messages for each connected
    ///     client.
    ///     The topic consists of one or more topic levels. Each topic level is separated by a forward slash (topic level
    ///     separator).
    /// </summary>
    /// <param name="topic">The MQTT topic</param>
    /// <returns>The <see cref="IApplicationMessageBuilder" /> being built</returns>
    public IApplicationMessageBuilder WithTopic(string? topic)
    {
        Topic = topic;
        return this;
    }

    /// <summary>
    ///     Adds the topic alias to the message.
    ///     <remarks>MQTT 5.0.0+ feature.</remarks>
    /// </summary>
    /// <param name="topicAlias">The 2-byte integer referring to or establishing a topic alias</param>
    /// <returns>The <see cref="IApplicationMessageBuilder" /> being built</returns>
    public IApplicationMessageBuilder WithTopicAlias(ushort topicAlias)
    {
        TopicAlias = topicAlias;
        return this;
    }

    /// <summary>
    ///     Adds the user property to the message.
    ///     <remarks>MQTT 5.0.0+ feature.</remarks>
    /// </summary>
    /// <param name="name">The user property name</param>
    /// <param name="value">The user property value</param>
    /// <returns>The <see cref="IApplicationMessageBuilder" /> being built</returns>
    public IApplicationMessageBuilder WithUserProperty(string name, string value)
    {
        UserProperties ??= new List<KeyValuePair<string, string>>();
        UserProperties.Add(new KeyValuePair<string, string>(name, value));
        return this;
    }
}
