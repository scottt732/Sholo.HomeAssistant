using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client
{
    [PublicAPI]
    public static class HomeAssistantClientConfigurationBuilderExtensions
    {
        public static IHomeAssistantClientConfigurationBuilder WithStateDeserializer<TStateDeserializer>(this IHomeAssistantClientConfigurationBuilder configurationBuilder)
            where TStateDeserializer : class, IStateDeserializer
        {
            configurationBuilder.ServiceCollection.AddSingleton<IStateDeserializer, TStateDeserializer>();
            return configurationBuilder;
        }

        public static IHomeAssistantClientConfigurationBuilder WithEntityStateDeserializer<TEntityStateDeserializer>(this IHomeAssistantClientConfigurationBuilder configurationBuilder)
            where TEntityStateDeserializer : class, IEntityStateDeserializer
        {
            configurationBuilder.ServiceCollection.AddSingleton<IEntityStateDeserializer, TEntityStateDeserializer>();
            return configurationBuilder;
        }

        public static IHomeAssistantClientConfigurationBuilder WithStateCodeGenerator(this IHomeAssistantClientConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.ServiceCollection.AddSingleton<IStateCodeGenerator, StateCodeGenerator>();
            return configurationBuilder;
        }

        public static IHomeAssistantClientConfigurationBuilder WithStateCodeGenerator<TStateCodeGenerator>(this IHomeAssistantClientConfigurationBuilder configurationBuilder)
            where TStateCodeGenerator : class, IStateCodeGenerator
        {
            configurationBuilder.ServiceCollection.AddSingleton<IStateCodeGenerator, TStateCodeGenerator>();
            return configurationBuilder;
        }
    }
}
