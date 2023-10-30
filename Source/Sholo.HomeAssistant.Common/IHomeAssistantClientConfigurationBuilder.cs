namespace Sholo.HomeAssistant;

[PublicAPI]
public interface IHomeAssistantClientConfigurationBuilder
{
    IHomeAssistantServiceCollection ServiceCollection { get; }
}
