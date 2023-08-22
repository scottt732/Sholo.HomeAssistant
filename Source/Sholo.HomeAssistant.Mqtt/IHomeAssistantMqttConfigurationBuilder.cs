using JetBrains.Annotations;
using Sholo.HomeAssistant.DependencyInjection;

namespace Sholo.HomeAssistant.Mqtt
{
    [PublicAPI]
    public interface IHomeAssistantMqttConfigurationBuilder
    {
        IHomeAssistantServiceCollection ServiceCollection { get; }
    }
}
