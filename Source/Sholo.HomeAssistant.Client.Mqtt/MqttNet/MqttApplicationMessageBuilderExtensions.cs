using System;
using MQTTnet;
using MQTTnet.Protocol;

namespace Sholo.HomeAssistant.Client.Mqtt.MqttNet;

internal static class MqttApplicationMessageBuilderExtensions
{
    public static MqttApplicationMessageBuilder WithQualityOfServiceLevel(this MqttApplicationMessageBuilder builder, QualityOfServiceLevel qualityOfServiceLevel)
    {
        return builder.WithQualityOfServiceLevel(qualityOfServiceLevel switch
        {
            QualityOfServiceLevel.AtLeastOnce => MqttQualityOfServiceLevel.AtLeastOnce,
            QualityOfServiceLevel.AtMostOnce => MqttQualityOfServiceLevel.AtMostOnce,
            QualityOfServiceLevel.ExactlyOnce => MqttQualityOfServiceLevel.ExactlyOnce,
            _ => throw new ArgumentOutOfRangeException(nameof(qualityOfServiceLevel))
        });
    }
}
