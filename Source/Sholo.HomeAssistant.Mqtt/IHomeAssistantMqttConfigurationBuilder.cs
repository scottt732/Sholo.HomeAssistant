using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant.Mqtt
{
    [PublicAPI]
    public interface IHomeAssistantMqttConfigurationBuilder
    {
        IConfiguration HomeAssistantRootConfiguration { get; }
        IConfiguration MqttRootConfiguration { get; }
        IServiceCollection ServiceCollection { get; }
    }
}
