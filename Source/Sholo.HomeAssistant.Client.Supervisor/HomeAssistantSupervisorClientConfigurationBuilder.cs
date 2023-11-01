using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant.Client;

[PublicAPI]
public class HomeAssistantSupervisorClientConfigurationBuilder : IHomeAssistantSupervisorClientConfigurationBuilder
{
    public IConfiguration Configuration { get; }
    public IServiceCollection ServiceCollection { get; }

    public HomeAssistantSupervisorClientConfigurationBuilder(IHomeAssistantConfigurationBuilder configurationBuilder)
    {
        Configuration = configurationBuilder.Configuration.GetSection("client:supervisor");
        ServiceCollection = configurationBuilder.Services;
    }
}
