using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;
using Sholo.HomeAssistant.StateDeserializers;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantClientConfigurationBuilderExtensions
{
    public static IHomeAssistantHttpClientConfigurationBuilder WithStateDeserializer<TStateDeserializer>(this IHomeAssistantHttpClientConfigurationBuilder configurationBuilder)
        where TStateDeserializer : class, IStateDeserializer
    {
        configurationBuilder.ServiceCollection.AddSingleton<IStateDeserializer, TStateDeserializer>();
        return configurationBuilder;
    }

    public static IHomeAssistantHttpClientConfigurationBuilder WithEntityStateDeserializer<TEntityStateDeserializer>(this IHomeAssistantHttpClientConfigurationBuilder configurationBuilder)
        where TEntityStateDeserializer : class, IEntityStateDeserializer
    {
        configurationBuilder.ServiceCollection.AddSingleton<IEntityStateDeserializer, TEntityStateDeserializer>();
        return configurationBuilder;
    }

    public static IHomeAssistantHttpClientConfigurationBuilder WithStateCodeGenerator<TStateCodeGenerator>(this IHomeAssistantHttpClientConfigurationBuilder configurationBuilder)
        where TStateCodeGenerator : class, IStateCodeGenerator
    {
        configurationBuilder.ServiceCollection.AddSingleton<IStateCodeGenerator, TStateCodeGenerator>();
        return configurationBuilder;
    }
}
