using JetBrains.Annotations;
using Sholo.HomeAssistant.DependencyInjection;

namespace Sholo.HomeAssistant.Client
{
    [PublicAPI]
    public interface IHomeAssistantClientConfigurationBuilder
    {
        IHomeAssistantServiceCollection ServiceCollection { get; }
    }
}
