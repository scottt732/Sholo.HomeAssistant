using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Sholo.HomeAssistant.Validation;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class ServiceCollectionExtensions
{
    public static IHomeAssistantConfigurationBuilder AddHomeAssistant(this IServiceCollection services, IConfiguration configuration)
    {
        services.TryAddSingleton<IDomainRegistry, DomainRegistry>();
        services.TryAddSingleton<ILoggerFactory, NullLoggerFactory>();
        services.TryAddTransient(typeof(ILogger<>), typeof(NullLogger<>));

        services.AddSingleton<IValidator, Validator>();

        return new HomeAssistantConfigurationBuilder(services, configuration);
    }
}
