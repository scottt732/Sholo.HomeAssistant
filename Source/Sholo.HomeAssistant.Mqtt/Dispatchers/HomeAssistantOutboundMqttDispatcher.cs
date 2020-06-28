using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using MQTTnet.Extensions.ManagedClient;

namespace Sholo.HomeAssistant.Mqtt.Dispatchers
{
    public class HomeAssistantOutboundMqttDispatcher : IHostedService
    {
        private IManagedMqttClient ManagedMqttClient { get; }
        private IMqttEntityControlPanel MqttEntityControlPanel { get; }
        private IOutboundMqttMessageBusConsumer MessageBusConsumer { get; }
        private IDisposable MessageBusSubscription { get; set; }

        public HomeAssistantOutboundMqttDispatcher(
            IManagedMqttClient managedMqttClient,
            IMqttEntityControlPanel mqttEntityControlPanel,
            IOutboundMqttMessageBusConsumer messageBusConsumer
        )
        {
            ManagedMqttClient = managedMqttClient;
            MqttEntityControlPanel = mqttEntityControlPanel;
            MessageBusConsumer = messageBusConsumer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            MessageBusSubscription = MessageBusConsumer.Bind(ManagedMqttClient);
            MqttEntityControlPanel.ResendDiscovery();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            MqttEntityControlPanel.Dispose();
            MessageBusSubscription.Dispose();
            return Task.CompletedTask;
        }
    }
}
