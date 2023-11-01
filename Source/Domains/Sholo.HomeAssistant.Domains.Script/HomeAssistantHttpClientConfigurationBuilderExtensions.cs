using Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantHttpClientConfigurationBuilderExtensions
{
    public static IHomeAssistantHttpClientConfigurationBuilder AddScript(this IHomeAssistantHttpClientConfigurationBuilder httpClientConfigurationBuilder)
    {
        return httpClientConfigurationBuilder.AddDomain<ScriptDomain, ScriptEntityStateDeserializer>();
    }
}
