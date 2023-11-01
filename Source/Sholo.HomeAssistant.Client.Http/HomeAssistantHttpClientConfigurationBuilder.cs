using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant.Client;

public class HomeAssistantHttpClientConfigurationBuilder : IHomeAssistantHttpClientConfigurationBuilder
{
    public IConfiguration Configuration { get; }
    public IServiceCollection ServiceCollection { get; }

    public HomeAssistantHttpClientConfigurationBuilder(IHomeAssistantConfigurationBuilder configurationBuilder)
    {
        ServiceCollection = configurationBuilder.Services;
        Configuration = configurationBuilder.Configuration.GetSection("client:http");
    }
}
