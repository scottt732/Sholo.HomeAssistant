using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Group
{
    [PublicAPI]
    public class GroupStateAttributes
    {
        public string[] EntityId { get; set; }
        public string FriendlyName { get; set; }
        public string Icon { get; set; }
        public int? Order { get; set; }
    }
}
