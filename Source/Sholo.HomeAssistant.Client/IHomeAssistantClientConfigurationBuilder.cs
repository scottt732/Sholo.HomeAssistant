using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant.Client
{
    [PublicAPI]
    public interface IHomeAssistantClientConfigurationBuilder
    {
        IConfiguration HomeAssistantRootConfiguration { get; }
        IConfiguration ClientRootConfiguration { get; }
        IServiceCollection ServiceCollection { get; }
    }
}
