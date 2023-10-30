using System;
using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;

namespace Sholo.HomeAssistant.Client.Mqtt.MqttNet;

internal static class ApplicationMessageExtensions
{
    public static MqttApplicationMessage ToMqttNetApplicationMessage(this IApplicationMessage message)
    {
        var builder = new MqttApplicationMessageBuilder();

        if (message.ContentType != null)
        {
            builder.WithContentType(message.ContentType);
        }

        if (message.CorrelationData != null)
        {
            builder.WithCorrelationData(message.CorrelationData);
        }

        builder.WithMessageExpiryInterval(message.MessageExpiryInterval);

        if (message.Payload != null)
        {
            builder.WithPayload(message.Payload);
        }

        builder.WithPayloadFormatIndicator(message.PayloadFormatIndicator switch
        {
            PayloadFormatIndicator.Unspecified => MqttPayloadFormatIndicator.Unspecified,
            PayloadFormatIndicator.CharacterData => MqttPayloadFormatIndicator.CharacterData,
            _ => throw new ArgumentOutOfRangeException(nameof(message), $"The {nameof(IApplicationMessage.PayloadFormatIndicator)} value is invalid")
        });

        builder.WithQualityOfServiceLevel(message.QualityOfServiceLevel switch
        {
            QualityOfServiceLevel.AtMostOnce => MqttQualityOfServiceLevel.AtMostOnce,
            QualityOfServiceLevel.AtLeastOnce => MqttQualityOfServiceLevel.AtLeastOnce,
            QualityOfServiceLevel.ExactlyOnce => MqttQualityOfServiceLevel.ExactlyOnce,
            _ => throw new ArgumentOutOfRangeException(nameof(message), $"The {nameof(IApplicationMessage.QualityOfServiceLevel)} value is invalid")
        });

        if (message.ResponseTopic != null)
        {
            builder.WithResponseTopic(message.ResponseTopic);
        }

        builder.WithRetainFlag(message.Retain);

        if (message.SubscriptionIdentifiers != null)
        {
            foreach (var subscriptionIdentifier in message.SubscriptionIdentifiers)
            {
                builder.WithSubscriptionIdentifier(subscriptionIdentifier);
            }
        }

        if (message.Topic != null)
        {
            builder.WithTopic(message.Topic);
        }

        builder.WithTopicAlias(message.TopicAlias);

        if (message.UserProperties != null)
        {
            foreach (var (name, value) in message.UserProperties)
            {
                builder.WithUserProperty(name, value);
            }
        }

        return builder.Build();
    }
}
