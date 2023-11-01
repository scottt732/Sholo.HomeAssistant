using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.StateDeserializers;

namespace Sholo.HomeAssistant;

[PublicAPI]
public interface IHomeAssistantHttpClientConfigurationBuilder
{
    IConfiguration Configuration { get; }
    IServiceCollection ServiceCollection { get; }

    IHomeAssistantHttpClientConfigurationBuilder AddDomain<TDomain, TStateDeserializer>()
        where TDomain : class, IDomain, new()
        where TStateDeserializer : class, IStateDeserializer;
}
