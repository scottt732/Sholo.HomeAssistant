using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BaseServiceCollectionExtender = Sholo.HomeAssistant.Utilities.DependencyInjection.BaseServiceCollectionExtender;

namespace Sholo.HomeAssistant;

public class HomeAssistantServiceCollection : BaseServiceCollectionExtender, IHomeAssistantServiceCollection
{
    public IConfiguration Configuration { get; }

    public HomeAssistantServiceCollection(IServiceCollection target, IConfiguration configuration)
        : base(target)
    {
        Configuration = configuration;
    }
}
