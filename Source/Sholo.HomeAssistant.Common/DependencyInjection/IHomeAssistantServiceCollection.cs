using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant.DependencyInjection
{
    [PublicAPI]
    public interface IHomeAssistantServiceCollection : IServiceCollection
    {
        IConfiguration Configuration { get; }
    }
}
