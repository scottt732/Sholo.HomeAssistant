using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant;

[PublicAPI]
public interface IHomeAssistantServiceCollection : IServiceCollection
{
    IConfiguration Configuration { get; }
}
