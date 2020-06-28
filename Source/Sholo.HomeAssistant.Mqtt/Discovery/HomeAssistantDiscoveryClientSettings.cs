using JetBrains.Annotations;
using MQTTnet.Protocol;

namespace Sholo.HomeAssistant.Mqtt.Discovery
{
    [PublicAPI]
    public class HomeAssistantDiscoveryClientSettings
    {
        public string DiscoveryPrefix { get; set; } = "homeassistant";
        public MqttQualityOfServiceLevel? QualityOfService { get; set; }
        public bool Retain { get; set; }
    }
}
