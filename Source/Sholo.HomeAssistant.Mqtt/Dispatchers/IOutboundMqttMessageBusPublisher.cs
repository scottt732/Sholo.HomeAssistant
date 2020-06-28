using MQTTnet;

namespace Sholo.HomeAssistant.Mqtt.Dispatchers
{
    public interface IOutboundMqttMessageBusPublisher
    {
        void PublishMessage(MqttApplicationMessage message);
    }
}