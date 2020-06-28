namespace Sholo.HomeAssistant.Client.Context
{
    public class HomeAssistantServicesContext : IHomeAssistantServicesContext
    {
        public IHomeAssistantContext Context { get; }

        public HomeAssistantServicesContext(IHomeAssistantContext context)
        {
            Context = context;
        }
    }
}
