using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.Discovery;

[PublicAPI]
public interface IHomeAssistantDiscoveryClient
{
    IOptions<HomeAssistantDiscoveryClientSettings> Settings { get; }

    Task SendDiscoveryAsync<TEntityDefinition>(string topic, TEntityDefinition payload, CancellationToken cancellationToken = default)
        where TEntityDefinition : IEntityDefinition;

    Task SendDeleteAsync(string topic, CancellationToken cancellationToken = default);
}
