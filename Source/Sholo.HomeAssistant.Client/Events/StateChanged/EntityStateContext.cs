using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Events.StateChanged
{
    [PublicAPI]
    public class EntityStateContext
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string UserId { get; set; }
    }
}
