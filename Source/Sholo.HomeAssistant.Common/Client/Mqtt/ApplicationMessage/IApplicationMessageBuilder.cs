using System;
using System.Collections.Generic;
using System.IO;

namespace Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;

/// <summary>
/// This is an abstraction around MQTT.Net's MqttApplicationMessageBuilder. The purpose of this is to allow for the MQTT and
/// non-MQTT-related data structures to exist in the HomeAssistant.Domains.* projects without having to reference MQTT.Net
/// since projects opting only for REST or WebSockets will not need/may not want the dependency.
/// </summary>
/// <remarks>
/// See <a href="https://github.com/dotnet/MQTTnet">MQTT.NET</a> for details on the MQTT.Net project, which the
/// HomeAssistant.Client.Mqtt depends on. Some of the code here was copied &amp; modified from that project. Translation between
/// interfaces happens in the internal HomeAssistant.Client.Mqtt.MqttNet namespace
/// </remarks>
[PublicAPI]
public interface IApplicationMessageBuilder
{
    IApplicationMessage Build();

    IApplicationMessageBuilder WithContentType(string contentType);

    IApplicationMessageBuilder WithCorrelationData(byte[] correlationData);

    IApplicationMessageBuilder WithMessageExpiryInterval(uint messageExpiryInterval);

    IApplicationMessageBuilder WithPayload(byte[]? payload);
    IApplicationMessageBuilder WithPayload(ArraySegment<byte>? payloadSegment);
    IApplicationMessageBuilder WithPayload(IEnumerable<byte>? payload);
    IApplicationMessageBuilder WithPayload(Stream? payload);
    IApplicationMessageBuilder WithPayload(Stream? payload, long length);
    IApplicationMessageBuilder WithPayload(string? payload);
    IApplicationMessageBuilder WithPayloadFormatIndicator(PayloadFormatIndicator payloadFormatIndicator);
    IApplicationMessageBuilder WithPayloadSegment(ArraySegment<byte> payloadSegment);
    IApplicationMessageBuilder WithPayloadSegment(ReadOnlyMemory<byte> payloadSegment);
    IApplicationMessageBuilder WithQualityOfServiceLevel(QualityOfServiceLevel qualityOfServiceLevel);
    IApplicationMessageBuilder WithResponseTopic(string responseTopic);
    IApplicationMessageBuilder WithRetainFlag(bool? value = true);
    IApplicationMessageBuilder WithSubscriptionIdentifier(uint subscriptionIdentifier);
    IApplicationMessageBuilder WithTopic(string topic);
    IApplicationMessageBuilder WithTopicAlias(ushort topicAlias);
    IApplicationMessageBuilder WithUserProperty(string name, string value);
}
