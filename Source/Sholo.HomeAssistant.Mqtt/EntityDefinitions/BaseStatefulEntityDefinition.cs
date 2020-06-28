using MQTTnet.Protocol;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions
{
    public abstract class BaseStatefulEntityDefinition : BaseEntityDefinition, IStatefulEntityDefinition
    {
        public string AvailabilityTopic { get; internal set; }
        public string JsonAttributesTemplate { get; internal set; }
        public string JsonAttributesTopic { get; internal set; }
        public string PayloadAvailable { get; internal set; }
        public string PayloadNotAvailable { get; internal set; }
        public MqttQualityOfServiceLevel? Qos { get; internal set; }
        public bool? Retain { get; internal set; }
        public string StateTopic { get; internal set; }
        public string ValueTemplate { get; internal set; }
    }
}
