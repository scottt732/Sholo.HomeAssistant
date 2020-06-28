namespace Sholo.HomeAssistant.Client.Context
{
    public class HomeAssistantEntitiesContext : IHomeAssistantEntitiesContext
    {
        public IHomeAssistantContext Context { get; }

        public HomeAssistantEntitiesContext(IHomeAssistantContext context)
        {
            Context = context;
        }
    }
}
