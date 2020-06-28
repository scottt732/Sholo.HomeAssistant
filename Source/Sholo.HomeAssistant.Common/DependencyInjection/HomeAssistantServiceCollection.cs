using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sholo.Utils;

namespace Sholo.HomeAssistant.DependencyInjection
{
    public class HomeAssistantServiceCollection : BaseServiceCollectionExtender, IHomeAssistantServiceCollection
    {
        public IConfiguration Configuration { get; }

        public HomeAssistantServiceCollection(IServiceCollection target, IConfiguration configuration)
            : base(target)
        {
            Configuration = configuration;
        }
    }
}
