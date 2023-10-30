using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Extensions.ManagedClient;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.MessageBus;

namespace Sholo.HomeAssistant.Client.Mqtt.MqttNet;

public class MqttMessageBus : IMqttMessageBus
{
    private IManagedMqttClient Client { get; }
    private ILogger<MqttMessageBus> Logger { get; }

    public MqttMessageBus(
        IManagedMqttClient client,
        ILogger<MqttMessageBus> logger)
    {
        Client = client;
        Logger = logger;
    }

    private Subject<MqttApplicationMessage> MessageBus { get; } = new();

    public void PublishMessage(IApplicationMessage message) => MessageBus.OnNext(message.ToMqttNetApplicationMessage());

    public IDisposable Bind() => MessageBus
        .ObserveOn(Scheduler.CurrentThread)
        .Select(m => Observable.FromAsync(() => SendMessageAsync(Client, m)))
        .Concat()
        .Subscribe();

    private async Task SendMessageAsync(IManagedMqttClient client, MqttApplicationMessage message)
    {
        Logger.LogDebug("< [{Topic}] {Payload}", message.Topic, message.ConvertPayloadToString());
        await client.EnqueueAsync(message);
    }
}
