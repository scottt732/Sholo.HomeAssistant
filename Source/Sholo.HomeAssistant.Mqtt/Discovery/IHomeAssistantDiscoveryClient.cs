using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using MQTTnet.Client.Publishing;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.Discovery
{
    [PublicAPI]
    public interface IHomeAssistantDiscoveryClient
    {
        IOptions<HomeAssistantDiscoveryClientSettings> Settings { get; }

        Task<MqttClientPublishResult> SendDiscoveryAsync<TEntityDefinition>(string topic, TEntityDefinition payload, CancellationToken cancellationToken = default)
            where TEntityDefinition : IEntityDefinition;

        Task<MqttClientPublishResult> SendDeleteAsync(string topic, CancellationToken cancellationToken = default);
    }
}
