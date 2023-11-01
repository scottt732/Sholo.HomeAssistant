using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant;

[PublicAPI]
public interface IHomeAssistantConfigurationBuilder
{
    IServiceCollection Services { get; }
    IConfiguration Configuration { get; }
}
