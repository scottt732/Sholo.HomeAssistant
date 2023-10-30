using System;
using MQTTnet.Protocol;

namespace Sholo.HomeAssistant.Client.Mqtt.MqttNet;

[PublicAPI]
internal static class QualityOfServiceLevelExtensions
{
    public static MqttQualityOfServiceLevel ToMqttNet(this QualityOfServiceLevel qualityOfServiceLevel)
        => qualityOfServiceLevel switch
        {
            QualityOfServiceLevel.AtMostOnce => MqttQualityOfServiceLevel.AtMostOnce,
            QualityOfServiceLevel.AtLeastOnce => MqttQualityOfServiceLevel.AtLeastOnce,
            QualityOfServiceLevel.ExactlyOnce => MqttQualityOfServiceLevel.ExactlyOnce,
            _ => throw new ArgumentOutOfRangeException(nameof(qualityOfServiceLevel), $"The {nameof(QualityOfServiceLevel)} value is invalid")
        };

    public static MqttQualityOfServiceLevel? ToMqttNet(this QualityOfServiceLevel? qualityOfServiceLevel)
        => !qualityOfServiceLevel.HasValue ? null : ToMqttNet(qualityOfServiceLevel.Value);
}
