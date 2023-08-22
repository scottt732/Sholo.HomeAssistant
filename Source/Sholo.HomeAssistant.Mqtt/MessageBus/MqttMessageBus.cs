using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Extensions.ManagedClient;

namespace Sholo.HomeAssistant.Mqtt.MessageBus
{
    public class MqttMessageBus : IMqttMessageBus
    {
        private ILogger<MqttMessageBus> Logger { get; }

        public MqttMessageBus(ILogger<MqttMessageBus> logger)
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
            Logger.LogInformation("< [{Topic}] {Payload}", message.Topic, message.ConvertPayloadToString());
            await client.PublishAsync(message);
        }
    }
}
