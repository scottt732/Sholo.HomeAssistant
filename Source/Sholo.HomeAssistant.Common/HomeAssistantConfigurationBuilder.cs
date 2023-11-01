using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BaseServiceCollectionExtender = Sholo.HomeAssistant.Utilities.DependencyInjection.BaseServiceCollectionExtender;

namespace Sholo.HomeAssistant;

public class HomeAssistantConfigurationBuilder : BaseServiceCollectionExtender, IHomeAssistantConfigurationBuilder
{
    public IServiceCollection Services { get; }
    public IConfiguration Configuration { get; }

    public HomeAssistantConfigurationBuilder(IServiceCollection target, IConfiguration configuration)
        : base(target)
    {
        Services = target;
        Configuration = configuration;
    }
}
