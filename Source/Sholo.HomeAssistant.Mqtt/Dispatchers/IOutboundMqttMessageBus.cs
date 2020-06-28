namespace Sholo.HomeAssistant.Mqtt.Dispatchers
{
    public interface IOutboundMqttMessageBus : IOutboundMqttMessageBusPublisher, IOutboundMqttMessageBusConsumer
    {
    }
}