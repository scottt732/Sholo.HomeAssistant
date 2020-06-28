using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.Context;

namespace Sholo.HomeAssistant.Client.Services
{
    [PublicAPI]
    public abstract class BaseServiceSet : IServiceSet
    {
        protected IHomeAssistantContext Context { get; }

        protected BaseServiceSet(IHomeAssistantContext context)
        {
            Context = context;
        }
    }
}
