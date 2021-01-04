using System;
using MQTTnet;
using MQTTnet.Extensions.ManagedClient;

namespace Sholo.HomeAssistant.Mqtt.MessageBus
{
    public interface IMqttMessageBus
    {
        void PublishMessage(MqttApplicationMessage message);
        IDisposable Bind(IManagedMqttClient client);
    }
}
