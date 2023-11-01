using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sholo.HomeAssistant.StateDeserializers;

namespace Sholo.HomeAssistant;

[PublicAPI]
public class HomeAssistantHttpConfigurationBuilder : IHomeAssistantHttpClientConfigurationBuilder
{
    public IConfiguration Configuration { get; }
    public IServiceCollection ServiceCollection { get; }

    public HomeAssistantHttpConfigurationBuilder(IHomeAssistantConfigurationBuilder configurationBuilder)
    {
        Configuration = configurationBuilder.Configuration.GetSection("client:http");
        ServiceCollection = configurationBuilder.Services;
    }

    public IHomeAssistantHttpClientConfigurationBuilder AddDomain<TDomain, TStateDeserializer>()
        where TDomain : class, IDomain, new()
        where TStateDeserializer : class, IStateDeserializer
    {
        ServiceCollection.TryAddSingleton<IDomain, TDomain>();
        ServiceCollection.AddSingleton<IStateDeserializer, TStateDeserializer>();
        return this;
    }
}
