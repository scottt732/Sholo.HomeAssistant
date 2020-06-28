using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Extensions.ManagedClient;

namespace Sholo.HomeAssistant.Mqtt.Dispatchers
{
    public class OutboundMqttMessageBus : IOutboundMqttMessageBus
    {
        private ILogger<OutboundMqttMessageBus> Logger { get; }

        public OutboundMqttMessageBus(ILogger<OutboundMqttMessageBus> logger)
        {
            Logger = logger;
        }

        private Subject<MqttApplicationMessage> MessageBus { get; } = new Subject<MqttApplicationMessage>();

        public void PublishMessage(MqttApplicationMessage message) => MessageBus.OnNext(message);

        public IDisposable Bind(IManagedMqttClient client) => MessageBus
            .ObserveOn(Scheduler.CurrentThread)
            .Select(m => Observable.FromAsync(() => SendMessage(client, m)))
            .Concat()
            .Subscribe();

        private async Task SendMessage(IManagedMqttClient client, MqttApplicationMessage message)
        {
            Logger.LogInformation("< [{topic}] {payload}", message.Topic, message.ConvertPayloadToString());
            await client.PublishAsync(message);
        }
    }
}
