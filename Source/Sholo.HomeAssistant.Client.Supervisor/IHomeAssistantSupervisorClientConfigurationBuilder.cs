using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant.Client;

[PublicAPI]
public interface IHomeAssistantSupervisorClientConfigurationBuilder
{
    IConfiguration Configuration { get; }
    IServiceCollection ServiceCollection { get; }
}
