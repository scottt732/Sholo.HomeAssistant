using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client.Publishing;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Serialization;

namespace Sholo.HomeAssistant.Mqtt.Discovery
{
    public class HomeAssistantDiscoveryClient : IHomeAssistantDiscoveryClient
    {
        public IOptions<HomeAssistantDiscoveryClientSettings> Settings { get; }

        private IManagedMqttClient MqttClient { get; }
        private ILogger Logger { get; }
        private JsonSerializer JsonSerializer { get; }

        public HomeAssistantDiscoveryClient(
            IManagedMqttClient mqttClient,
            IOptions<HomeAssistantDiscoveryClientSettings> homeAssistantDiscoveryClientOptions,
            ILogger<HomeAssistantDiscoveryClient> logger
        )
        {
            Settings = homeAssistantDiscoveryClientOptions;
            MqttClient = mqttClient;
            Logger = logger;

            JsonSerializer = JsonSerializer.Create(HomeAssistantSerializerSettings.JsonSerializerSettings);
        }

        public async Task<MqttClientPublishResult> SendDiscoveryAsync<TEntityDefinition>(
            string topic,
            TEntityDefinition payload,
            CancellationToken cancellationToken = default)
                where TEntityDefinition : IEntityDefinition
        {
            var payloadString = GetPayloadString(payload);

            var messageBuilder = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payloadString)
                .WithRetainFlag(Settings.Value.Retain);

            if (Settings.Value.QualityOfService.HasValue)
            {
                messageBuilder = messageBuilder.WithQualityOfServiceLevel(Settings.Value.QualityOfService.Value);
            }

            Logger.LogInformation("[{Topic}] {Payload}", topic, payloadString);

            var message = messageBuilder.Build();

            var result = await MqttClient.PublishAsync(message, cancellationToken);
            return result;
        }

        public async Task<MqttClientPublishResult> SendDeleteAsync(
            string topic,
            CancellationToken cancellationToken = default)
        {
            var messageBuilder = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(Array.Empty<byte>())
                .WithRetainFlag(Settings.Value.Retain);

            if (Settings.Value.QualityOfService.HasValue)
            {
                messageBuilder = messageBuilder.WithQualityOfServiceLevel(Settings.Value.QualityOfService.Value);
            }

            var message = messageBuilder.Build();
            var result = await MqttClient.PublishAsync(message, cancellationToken);
            return result;
        }

        private string GetPayloadString<TEntityDefinition>(TEntityDefinition payload)
            where TEntityDefinition : IEntityDefinition
        {
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                JsonSerializer.Serialize(sw, payload);
                return sb.ToString();
            }
        }
    }
}
