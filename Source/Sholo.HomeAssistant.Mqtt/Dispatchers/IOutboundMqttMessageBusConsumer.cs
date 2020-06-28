using System;
using MQTTnet.Extensions.ManagedClient;

namespace Sholo.HomeAssistant.Mqtt.Dispatchers
{
    public interface IOutboundMqttMessageBusConsumer
    {
        IDisposable Bind(IManagedMqttClient client);
    }
}