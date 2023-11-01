using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.MessageBus;
using Sholo.Mqtt.Application.Provider;

namespace Sholo.HomeAssistant.Client.Mqtt.Services;

public class HomeAssistantOutboundMqttDispatcher : IHostedService
{
    private IMqttApplicationProvider MqttApplicationProvider { get; }
    private IMqttEntityControlPanelHost MqttEntityControlPanel { get; }
    private IMqttMessageBus MessageBus { get; }
    private IDisposable MessageBusSubscription { get; set; }

    public HomeAssistantOutboundMqttDispatcher(
        IMqttApplicationProvider mqttApplicationProvider,
        IMqttEntityControlPanelHost mqttEntityControlPanel,
        IMqttMessageBus messageBus
    )
    {
        MqttApplicationProvider = mqttApplicationProvider;
        MqttEntityControlPanel = mqttEntityControlPanel;
        MessageBus = messageBus;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        MessageBusSubscription = MessageBus.Bind();
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
