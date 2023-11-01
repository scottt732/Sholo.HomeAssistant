using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant.Client;

public interface IHomeAssistantHttpClientConfigurationBuilder
{
    IConfiguration Configuration { get; }
    IServiceCollection ServiceCollection { get; }
}
