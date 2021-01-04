using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Sholo.HomeAssistant.Validation;

namespace Sholo.HomeAssistant.DependencyInjection
{
    [PublicAPI]
    public static class ServiceCollectionExtensions
    {
        public static IHomeAssistantServiceCollection AddHomeAssistant(this IServiceCollection services, IConfiguration homeAssistantConfigurationSection)
        {
            services.TryAddSingleton<ILoggerFactory, NullLoggerFactory>();
            services.TryAddTransient(typeof(ILogger<>), typeof(NullLogger<>));

            services.AddSingleton<IValidator, Validator>();

            return new HomeAssistantServiceCollection(services, homeAssistantConfigurationSection);
        }
    }
}
