using MQTTnet.Protocol;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.DeviceTrigger
{
    public class DeviceTriggerEntityDefinition : BaseEntityDefinition, IDeviceTriggerEntityDefinition
    {
        public string AutomationType { get; internal set; }
        public string Payload { get; internal set; }
        public MqttQualityOfServiceLevel? Qos { get; internal set; }
        public string Topic { get; internal set; }
        public DeviceTriggerType Type { get; internal set; }
        public DeviceTriggerSubType Subtype { get; internal set; }
    }
}