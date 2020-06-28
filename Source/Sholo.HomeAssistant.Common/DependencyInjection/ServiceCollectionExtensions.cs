using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Validation;

namespace Sholo.HomeAssistant.DependencyInjection
{
    [PublicAPI]
    public static class ServiceCollectionExtensions
    {
        public static IHomeAssistantServiceCollection AddHomeAssistant(this IServiceCollection services, IConfiguration homeAssistantConfigurationSection)
        {
            services.AddSingleton<IValidator, Validator>();

            return new HomeAssistantServiceCollection(services, homeAssistantConfigurationSection);
        }
    }
}
