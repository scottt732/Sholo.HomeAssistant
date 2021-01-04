using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using MQTTnet.Extensions.ManagedClient;
using Sholo.HomeAssistant.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Mqtt.MessageBus;
using Sholo.Mqtt.ApplicationProvider;

namespace Sholo.HomeAssistant.Mqtt.Dispatchers
{
    public class HomeAssistantOutboundMqttDispatcher : IHostedService
    {
        private IManagedMqttClient ManagedMqttClient { get; }
        private IMqttApplicationProvider MqttApplicationProvider { get; }
        private IMqttEntityControlPanel MqttEntityControlPanel { get; }
        private IMqttMessageBus MessageBus { get; }
        private IDisposable MessageBusSubscription { get; set; }

        public HomeAssistantOutboundMqttDispatcher(
            IManagedMqttClient managedMqttClient,
            IMqttApplicationProvider mqttApplicationProvider,
            IMqttEntityControlPanel mqttEntityControlPanel,
            IMqttMessageBus messageBus
        )
        {
            ManagedMqttClient = managedMqttClient;
            MqttApplicationProvider = mqttApplicationProvider;
            MqttEntityControlPanel = mqttEntityControlPanel;
            MessageBus = messageBus;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            MessageBusSubscription = MessageBus.Bind(ManagedMqttClient);
            MqttEntityControlPanel.BindAll(MqttApplicationProvider, MessageBus, true);
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
